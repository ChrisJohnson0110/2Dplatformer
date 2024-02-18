using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    [SerializeField] float HealAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameObject.FindGameObjectWithTag("Player").gameObject.tag)
        {
            GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Health>().Heal(this.gameObject, HealAmount);
            gameObject.SetActive(false);
        }
    }
}
