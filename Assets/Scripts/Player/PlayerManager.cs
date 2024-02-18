using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //references
    PlayerLocomotion playerLocomotion;
    PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLocomotion.HandleMovement();
        playerAttack.Attack();
    }


    //execute player death
    public void Death(GameObject a_goSource)
    {
        Debug.Log("Killed by: " + a_goSource.gameObject.name);
    }
}
