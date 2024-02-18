using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPickup : MonoBehaviour
{
    [SerializeField] PlayerEffects.Effects effectToApply;
    [SerializeField] float fDuration;
    [SerializeField] float fStrength;

    bool pickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameObject.FindGameObjectWithTag("Player").gameObject.tag)
        {
            if (pickedUp == false)
            {
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerEffects>().NewTempEffect(fDuration, effectToApply, fStrength);
                pickedUp = true;
                gameObject.SetActive(false);
            }
        }
    }
}
