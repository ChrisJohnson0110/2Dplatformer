using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbable : MonoBehaviour
{
    PlayerLocomotion ms;
    private InputController input = null;

    private void Start()
    {
        ms = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLocomotion>();
        input = ms.input;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameObject.FindGameObjectWithTag("Player").gameObject.tag)
        {
            if (input.RetrieveVerticalInput() != 0)
            {
                ms.climbing = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameObject.FindGameObjectWithTag("Player").gameObject.tag)
        {
            ms.climbing = false;
        }
    }

}
