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
        if (isFacingRight == true)
        {
            transform.position += new Vector3((returningProjectile ? -speed : speed), 0, 0) * Time.deltaTime;
            if (transform.position.x <= GameObject.FindGameObjectWithTag("Player").transform.position.x)
            {
                gameObject.SetActive(false);
            }
        }
        else if (isFacingRight == false)
        {
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
    }

    void ReturnProjectile()
    {
        returningProjectile = true;
    }

}
