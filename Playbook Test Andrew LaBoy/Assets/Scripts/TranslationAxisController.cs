using UnityEngine;

// TranslationAxisController is a type of AxisController that allows for translation of the controlled object along a given axis.
public class TranslationAxisController : AxisController
{
    // The axis of translation
    public Vector3 translationAxis;

    // Overridden method from AxisController. Begins translation operation.
    public override void StartOperation(GameObject obj)
    {
        isDragging = true;
        controlledObject = obj;
        // Starts the translation operation along the specified axis
        gimbalController.StartTranslating(controlledObject, translationAxis);
        // Changes the color of the controller to yellow to indicate that it's active
        behindMaterialPropertyBlock.SetColor("_BaseColor", Color.yellow);
        axisRenderer.SetPropertyBlock(behindMaterialPropertyBlock);
    }

    // Overridden method from AxisController. Stops the translation operation.
    public override void StopOperation()
    {
        isDragging = false;
        // Stops the translation operation
        gimbalController.StopTranslating();
        // Resets the color of the controller to its default color to indicate that it's not active
        behindMaterialPropertyBlock.SetColor("_BaseColor", defaultColor);
        axisRenderer.SetPropertyBlock(behindMaterialPropertyBlock);
    }
}
