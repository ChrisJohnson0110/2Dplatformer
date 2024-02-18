using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProperties : MonoBehaviour
{
    public float fSpeed;
    public float fDamage;
    public bool isFacingRight; //facing right ?

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (isFacingRight == true)
        {
            transform.position += new Vector3(fSpeed, 0, 0) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(-fSpeed, 0, 0) * Time.deltaTime;
        }

        float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").gameObject.transform.position);

        if (distance >= 50)
        {
            gameObject.SetActive(false);
        }
    }

}
