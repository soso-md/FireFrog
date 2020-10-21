using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour {

    public float distance = 50f;
    public Transform tongue;
    Vector3 point = new Vector3();
    Vector3 mouseScreenPosition;
    Vector3 lookAt; 
    bool  mouseButtonDown = false;

    void Update () {

        //if mouse button (left hand side) pressed
        if (Input.GetMouseButtonDown (0)) {
            
            //keep mouseButton Down
            mouseButtonDown = true; 
        } 

        //if mouse button (left hand side) released
        if (Input.GetMouseButtonUp (0)) {
            mouseButtonDown =false; 
            // Reset localScale
            tongue.localScale = new Vector3(1, tongue.localScale.y, tongue.localScale.z);
        }

        if (mouseButtonDown) {
            Debug.Log ("ShowTongue");

            tongue.localScale = new Vector3(10, tongue.localScale.y, tongue.localScale.z);

            // apply rotation to mouse position
            mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            lookAt = mouseScreenPosition;

            float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

            float AngleDeg = (180 / Mathf.PI) * AngleRad;

            tongue.rotation = Quaternion.Euler(0, 0, AngleDeg);

        }
    }
}