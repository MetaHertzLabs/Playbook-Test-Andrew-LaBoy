using UnityEngine;

// ScaleAxisController is a type of AxisController that allows for scaling of the controlled object along a given axis.
public class ScaleAxisController : AxisController
{
    // The axis of scaling
    public Vector3 scaleAxis;

    // Overridden method from AxisController. Begins scaling operation.
    public override void StartOperation(GameObject obj)
    {
        isDragging = true;
        controlledObject = obj;
        // Starts the scaling operation along the specified axis
        gimbalController.StartScaling(controlledObject, scaleAxis);
        // Changes the color of the controller to yellow to indicate that it's active
        behindMaterialPropertyBlock.SetColor("_BaseColor", Color.yellow);
        axisRenderer.SetPropertyBlock(behindMaterialPropertyBlock);
    }

    // Overridden method from AxisController. Stops the scaling operation.
    public override void StopOperation()
    {
        isDragging = false;
        // Stops the scaling operation
        gimbalController.StopScaling();
        // Resets the color of the controller to its default color to indicate that it's not active
        behindMaterialPropertyBlock.SetColor("_BaseColor", defaultColor);
        axisRenderer.SetPropertyBlock(behindMaterialPropertyBlock);
    }
}