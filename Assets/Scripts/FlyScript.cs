using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
public float speed = 0.1f;
    public float rotateSpeed = 10f;
 
    Vector3 newPosition;
 
    void Start ()
    {
        PositionChange();
    }
 
    void PositionChange()
    {
        newPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(0f, 5f));
    }
   
    void Update ()
    {
        if(Vector2.Distance(transform.position, newPosition) < 1)
            PositionChange();
 
        transform.position=Vector3.Lerp(transform.position,newPosition,Time.deltaTime*speed);
 
        LookAt2D(newPosition);
    }
 
    void LookAt2D(Vector3 lookAtPosition)
    {
        float distanceX = lookAtPosition.x - transform.position.x;
        float distanceY = lookAtPosition.y - transform.position.y;
        float angle = Mathf.Atan2(distanceX, distanceY) * Mathf.Rad2Deg;
       
        Quaternion endRotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * rotateSpeed);
    }
}




//https://forum.unity.com/threads/moving-object-in-random-position-in-scence-like-fly.328050/