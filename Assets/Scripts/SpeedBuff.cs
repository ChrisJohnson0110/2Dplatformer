using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    //PlayerLocomotion pl;
    PlayerEffects pe;
    public void Initialize(float a_fDuration, float a_fStrength)
    {
        fTimerDuration = a_fDuration;
        fSpeedModifier = a_fStrength;
    }

    float fTimerDuration;
    float fSpeedModifier;

    private void Start()
    {
        //pl = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerLocomotion>();
        pe = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerEffects>();

        //pl.maxSpeed = pl.maxSpeedStarting + SpeedModifier;
        //pl.fSpeedModifier 
        //pl.fSpeedModifier += fSpeedModifier;
        pe.SpeedModifierBuff += fSpeedModifier;
        pe.CalculateAllBuffs();
    }

    // Update is called once per frame
    void Update()
    {
        if (fTimerDuration > 0)
        {
            fTimerDuration -= Time.deltaTime;
        }
        else
        {
            //pl.fSpeedModifier -= fSpeedModifier;
            pe.SpeedModifierBuff -= fSpeedModifier;
            pe.CalculateAllBuffs();
            Destroy(this);
        }
    }
}
