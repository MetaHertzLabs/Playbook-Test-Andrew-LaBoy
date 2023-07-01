using UnityEngine;

//Executes in edit mode so the handles aren't white in edit mode
[ExecuteInEditMode]
// This class provides a base for different types of AxisControllers, such as ones for rotation, scaling, and translation.
public abstract class AxisController : MonoBehaviour
{
    // The object this controller manipulates
    public GameObject controlledObject;
    // The default color for the axis 
    public Color defaultColor;
    // Reference to the Gimbal controller
    protected Gimbal gimbalController;
    // Boolean to indicate if the user is dragging the controller
    protected bool isDragging;
    // MaterialPropertyBlock allows us to modify material properties per renderer instance
    protected MaterialPropertyBlock behindMaterialPropertyBlock;
    // Renderer for the controller
    protected Renderer axisRenderer;

    protected virtual void Awake()
    {
        axisRenderer = GetComponent<MeshRenderer>();
        behindMaterialPropertyBlock = new MaterialPropertyBlock();
        axisRenderer.GetPropertyBlock(behindMaterialPropertyBlock);
        behindMaterialPropertyBlock.SetColor("_BaseColor", defaultColor);
        axisRenderer.SetPropertyBlock(behindMaterialPropertyBlock);
    }

    protected virtual void Start()
    {
        // Find the Gimbal component in the scene and register the event handlers
        gimbalController = GameObject.FindObjectOfType<Gimbal>();
        gimbalController.OnControllerSelected += HandleControllerSelected;
        gimbalController.OnSelectionCanceled += HandleSelectionCanceled;
    }

    protected virtual void OnDestroy()
    {
        if (gimbalController != null)
        {
            // Unregister the event handlers when the AxisController is destroyed
            gimbalController.OnControllerSelected -= HandleControllerSelected;
            gimbalController.OnSelectionCanceled -= HandleSelectionCanceled;
        }
    }

    protected virtual void HandleControllerSelected(AxisController selectedController)
    {
        if (selectedController == this)
        {
            // When this AxisController is selected, start the operation
            StartOperation(controlledObject);
        }
    }

    protected virtual void HandleSelectionCanceled()
    {
        if (isDragging)
        {
            // When selection is canceled, stop the operation
            StopOperation();
        }
    }

    // Abstract methods for starting and stopping the operation. These will be implemented in child classes.
    public abstract void StartOperation(GameObject obj);

    public abstract void StopOperation();
}