using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineInteract : MonoBehaviour
{
    [SerializeField] InputController input = null;
    PlayerEffects playerEffects;

    [SerializeField] PlayerEffects.Shrines shrinePower;

    private void Awake()
    {
        playerEffects = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerEffects>();

        if (playerEffects.activeShrine == shrinePower)
        {
            //grey out
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameObject.FindGameObjectWithTag("Player").gameObject.tag)
        {
            if (input.RetrieveInteract())
            {
                if (playerEffects.activeShrine == shrinePower)
                {
                    //play  cant use effect
                }
                else
                {
                    playerEffects.activeShrine = shrinePower;
                    playerEffects.CalculateAllBuffs();
                }
            }
        }
    }
}
