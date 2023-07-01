using UnityEngine;

// This class allows an object to follow the position of another object (the target)
public class FollowPosition : MonoBehaviour
{
    public Transform target; // The target object that this object will follow
    public Vector3 baseOffset; // The base offset from the target object's position

    private void Update()
    {
        // Sets the position of this object to be the position of the target object plus the base offset
        transform.position = target.position + baseOffset;
    }
}