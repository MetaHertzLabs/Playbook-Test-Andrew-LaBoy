using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gimbal : MonoBehaviour
{
    // The GameObject currently being transformed by the gimbal
    public GameObject selectedObject;

    // The Input Actions for the gimbal, defined in a separate script
    public GimbalControls controls;

    // The axis (direction) for each possible transformation (null when not transforming)
    private Vector3? rotationAxis, translationAxis, scaleAxis;

    // The amount to translate/rotate/scale the selectedObject each frame
    private Vector2 transformDelta;

    // Speeds for the three types of transformations
    public float rotationSpeed, translationSpeed, scaleSpeed;

    // The AxisController that is currently active (the user is interacting with)
    private AxisController activeController;

    // Events that are triggered when an AxisController is selected or deselected
    public event Action<AxisController> OnControllerSelected;
    public event Action OnSelectionCanceled;

    private void Awake()
    {
        // Initialize the gimbal controls and setup listeners for the select and transform actions
        controls = new GimbalControls();
        controls.Gimbal.Select.performed += context => Select(true);
        controls.Gimbal.Select.canceled += context => Select(false);
        controls.Gimbal.Transform.performed += context => transformDelta = context.ReadValue<Vector2>();
        controls.Gimbal.Transform.canceled += context => transformDelta = Vector2.zero;
    }

    private void Update()
    {
        // If there's an active controller, call its corresponding transformation method with the current transform delta
        if (activeController != null)
        {
            if (activeController is RotationAxisController)
            {
                RotateSelectedObject(transformDelta);
            }
            else if (activeController is TranslationAxisController)
            {
                TranslateSelectedObject(transformDelta);
            }
            else if (activeController is ScaleAxisController)
            {
                ScaleSelectedObject(transformDelta);
            }
        }
    }

    // Enable the gimbal controls when the GameObject is enabled
    private void OnEnable()
    {
        controls.Gimbal.Enable();
    }

    // Disable the gimbal controls when the GameObject is disabled
    private void OnDisable()
    {
        controls.Gimbal.Disable();
    }

    // This method is called when the select action is performed or canceled
    private void Select(bool isSelected)
    {
        if (isSelected)
        {
            // When the select action is performed, cast a ray from the input position
            // and check if it hits an AxisController. If so, make it the active controller.
            Vector2 inputPosition = controls.Gimbal.InputPosition.ReadValue<Vector2>();
            Ray ray = Camera.main.ScreenPointToRay(inputPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                AxisController hitController = hit.transform.gameObject.GetComponent<AxisController>();
                if (hitController != null)
                {
                    activeController = hitController;
                    OnControllerSelected?.Invoke(hitController);
                }
            }
        }
        else if (!isSelected)
        {
            // When the select action is canceled, clear the active controller and stop transforming
            activeController = null;
            OnSelectionCanceled?.Invoke();
            transformDelta = Vector2.zero;
        }
    }

    // These methods are called to start and stop rotating the selected object
    public void StartRotating(GameObject obj, Vector3 axis)
    {
        selectedObject = obj;
        rotationAxis = axis;
    }

    public void StopRotating()
    {
        rotationAxis = null;
    }

    // This method is called each frame to rotate the selected object around the rotation axis
    public void RotateSelectedObject(Vector2 rotationInput)
    {
        if (selectedObject != null && rotationAxis.HasValue && controls.Gimbal.Select.ReadValue<float>() > 0.5f)
        {
            Vector3 rotation = rotationAxis.Value * (rotationInput.x + rotationInput.y) * rotationSpeed * Time.deltaTime;
            selectedObject.transform.Rotate(rotation, Space.World);
        }
    }

    // These methods are similar to the rotation ones, but for translation
    public void StartTranslating(GameObject obj, Vector3 axis)
    {
        selectedObject = obj;
        translationAxis = axis;
    }

    public void StopTranslating()
    {
        translationAxis = null;
    }

    // This method is called each frame to translate the selected object along the translation axis
    public void TranslateSelectedObject(Vector2 translationInput)
    {
        if (selectedObject != null && translationAxis.HasValue && controls.Gimbal.Select.ReadValue<float>() > 0.5f)
        {
            Vector3 translation = translationAxis.Value * (translationInput.x + translationInput.y) * translationSpeed * Time.deltaTime;
            selectedObject.transform.Translate(translation, Space.World);
        }
    }

    // These methods are similar to the previous ones, but for scaling
    public void StartScaling(GameObject obj, Vector3 axis)
    {
        selectedObject = obj;
        scaleAxis = axis;
    }

    public void StopScaling()
    {
        selectedObject = null;
        scaleAxis = null;
    }

    // This method is called each frame to scale the selected object along the scale axis
    public void ScaleSelectedObject(Vector2 scaleInput)
    {
        if (selectedObject != null && scaleAxis.HasValue && controls.Gimbal.Select.ReadValue<float>() > 0.5f)
        {
            Vector3 scaleChange = scaleAxis.Value * (scaleInput.x + scaleInput.y) * scaleSpeed * Time.deltaTime;
            Vector3 newScale = selectedObject.transform.localScale + scaleChange;
            selectedObject.transform.localScale = newScale;
        }
    }
}
