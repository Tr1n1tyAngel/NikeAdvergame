using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CameraBorders : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] float smooth;
    [SerializeField] private Vector2 minPos;
    [SerializeField] private Vector2 maxPos;

    private void Start()
    {
       
    }
    private void FixedUpdate()
    {
        if(transform.position!=target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(target.position.x,minPos.x,maxPos.x);
            targetPosition.y = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smooth);
        }
       
    }
}
