using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // private
    private bool onGround;
    private float friction;

    // public
    public bool GetOnGround()
    {
        return onGround;
    }
    public float GetFriction()
    {
        return friction;
    }

    //private
    private void OnCollisionEnter2D(Collision2D a_collision)
    {
        EvaluateCollision(a_collision);
        RetrieveFriction(a_collision);
    }

    private void OnCollisionStay2D(Collision2D a_collision)
    {
        EvaluateCollision(a_collision);
        RetrieveFriction(a_collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
        friction = 0;
    }

    // check collision with ground
    private void EvaluateCollision(Collision2D a_collision)
    {
        //check each contact point
        for (int i=0; i < a_collision.contactCount; i++)
        {
            Vector2 normal = a_collision.GetContact(i).normal;
            onGround |= normal.y >= 0.9f; //is the normal greater than 0.9? (1 = flat surface)
        }
    }

    //get material of collision object
    private void RetrieveFriction(Collision2D a_collision)
    {
        PhysicsMaterial2D material = a_collision.rigidbody.sharedMaterial;

        friction = 0; //set defualt

        //if material found
        if (material != null)
        {
            friction = material.friction;
        }
    }


}
