using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
     public float UpForce = 200f;
     public float speed = 50f;
     private bool canJump = false;
     Rigidbody2D rBody;

    float isGroundedRayLength =0.1f;
    LayerMask layerMaskForGrounded;
    public bool isGrounded {
                 get {
                         Vector3 position = transform.position;
                         position.y = GetComponent<Collider2D> ().bounds.min.y + 0.1f;
                         float length = isGroundedRayLength + 0.1f;
                         Debug.DrawRay (position, Vector3.down * length);
                         bool grounded = Physics2D.Raycast (position, Vector3.down, length, layerMaskForGrounded.value);
                         return grounded;
                 }
         }

    // Start is called before the first frame update
     void Start () {
         rBody = GetComponent<Rigidbody2D> ();
     }

void Update () {


            //hochsptingen
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0) && isGrounded)
        {   //Debug.Log("Taste");
            rBody.velocity = Vector2.zero;
            rBody.AddForce(new Vector2(0f, UpForce));
        }
    
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rBody.velocity = Vector2.zero;
            rBody.AddForce(new Vector2(speed * -1,rBody.velocity.y));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rBody.velocity = Vector2.zero;
            rBody.AddForce(new Vector2(speed,rBody.velocity.y));
        }

     }
 }


