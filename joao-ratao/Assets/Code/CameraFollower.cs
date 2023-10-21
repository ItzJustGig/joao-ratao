using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public Transform Target;
    public float smoothing;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    void LateUpdate()
    {
        transform.position = new Vector3(Target.transform.position.x,Target.transform.position.y, transform.position.z);
    
        if(transform.position != Target.position)
        {
            Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z); 
           
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
