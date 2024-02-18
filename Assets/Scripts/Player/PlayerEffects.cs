using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    PlayerLocomotion pl; //reference to player locomotion
    public enum Shrines //list of all shrines 
    {
        None,
        Speed,
        JumpBoost
    }
    public enum Effects //list of all effects
    {
        Speed,
        JumpBoost
    }

    public Shrines activeShrine; //current active shrine

    //shrines
    [SerializeField] float fSpeedModifierShrine;
    [SerializeField] float fJumpModifierShrine;

    //buffs
    [HideInInspector] public float SpeedModifierBuff;
    [HideInInspector] public float JumpModifierBuff;


    //end values
    [HideInInspector] public float speedModifierEndValue;
    [HideInInspector] public float jumpModifierEndValue;

    private void Start()
    {
        pl = gameObject.GetComponent<PlayerLocomotion>();
    }

    void Applyeffects()
    {
        speedModifierEndValue = fSpeedModifierShrine + SpeedModifierBuff;
        jumpModifierEndValue = fJumpModifierShrine + JumpModifierBuff;
    }

    //set shrine
    public void CalculateAllBuffs()
    {
        if (activeShrine == Shrines.Speed)
        {
            fSpeedModifierShrine = 2;
        }
        else
        {
            fSpeedModifierShrine = 0;
        }

        if (activeShrine == Shrines.JumpBoost)
        {
            fJumpModifierShrine = 2;
        }
        else
        {
            fJumpModifierShrine = 0;
        }
        Applyeffects();
    }

    //apply effects
    public void NewTempEffect(float a_fDuration, Effects a_eEffectToSet, float a_fStrength)
    {
        if (a_eEffectToSet == Effects.Speed)
        {
            SpeedBuff sb = pl.gameObject.AddComponent<SpeedBuff>();
            sb.Initialize(a_fDuration, a_fStrength);
        }
    }
}
