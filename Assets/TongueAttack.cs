using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueAttack : MonoBehaviour
{
    public bool returningProjectile = false;
    public bool isFacingRight = false;

    public float speed = 2;
    public float range = 5f;

    public Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        //if (isFacingRight == true)
        //{
        //    if (returningProjectile == false)
        //    {
        //        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //    }
        //    else
        //    {
        //        transform.Translate(-(Vector3.right * speed * Time.deltaTime));
        //    }
        //}
        //else
        //{
        //    if (returningProjectile == false)
        //    {
        //        transform.Translate(-Vector3.right * speed * Time.deltaTime);
        //    }
        //    else
        //    {
        //        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //    }
        //}

        if (isFacingRight == true)
        {
            //transform.Translate((returningProjectile ? -1 : 1) * Vector3.right * speed * Time.deltaTime);
            transform.position += new Vector3((returningProjectile ? -speed : speed), 0, 0) * Time.deltaTime;
            if (transform.position.x <= GameObject.FindGameObjectWithTag("Player").transform.position.x)
            {
                gameObject.SetActive(false);
            }
        }
        else if (isFacingRight == false)
        {
            //transform.Translate(-(returningProjectile ? 1 : -1) * Vector3.right * speed * Time.deltaTime);
            transform.position += new Vector3((returningProjectile ? speed : -speed), 0, 0) * Time.deltaTime;
            if (transform.position.x >= GameObject.FindGameObjectWithTag("Player").transform.position.x)
            {
                gameObject.SetActive(false);
            }
        }

        if (Vector3.Distance(initialPosition, transform.position) >= range)
        {
            ReturnProjectile();
        }

        //if (returningProjectile == false)
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Translate(-(Vector3.right * speed * Time.deltaTime));
        //}

        //check distance

        //if (Vector3.Distance(initialPosition, transform.position) >= range)
        //{
        //    ReturnProjectile();
        //}
        //check return
        //if (transform.position.x <= GameObject.FindGameObjectWithTag("Player").transform.position.x)
        //{
        //    gameObject.SetActive(false);
        //}
    }

    void ReturnProjectile()
    {
        //transform.position = initialPosition;
        returningProjectile = true;
    }

}
