using UnityEngine;

// RotationAxisController inherits from AxisController, allowing it to rotate the controlled object along a given axis.
public class RotationAxisController : AxisController
{
    // The axis of rotation
    public Vector3 rotationAxis;

    // Overridden method from AxisController. Begins translation operation.
    public override void StartOperation(GameObject obj)
    {
        isDragging = true;
        controlledObject = obj;
        // Start rotating the controlled object along the given axis
        gimbalController.StartRotating(controlledObject, rotationAxis);
        // Change the color of the controller to yellow to indicate that it's active
        behindMaterialPropertyBlock.SetColor("_BaseColor", Color.yellow);
        axisRenderer.SetPropertyBlock(behindMaterialPropertyBlock);
    }

    // Overridden method from AxisController. Stops the scaling operation.
    public override void StopOperation()
    {
        isDragging = false;
        // Stop rotating the controlled object
        gimbalController.StopRotating();
        // Reset the color of the controller to its default color to indicate that it's not active
        behindMaterialPropertyBlock.SetColor("_BaseColor", defaultColor);
        axisRenderer.SetPropertyBlock(behindMaterialPropertyBlock);
    }
}