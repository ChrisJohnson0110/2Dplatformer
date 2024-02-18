using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float MaxHitPoints;
    float HitPoints;

    private void Start()
    {
        HitPoints = MaxHitPoints;
    }
    public void TakeDamage(GameObject a_goSource, float a_fDamageToTake)
    {
        HitPoints -= a_fDamageToTake;
        DeathCheck(a_goSource);
    }

    public void Heal(GameObject a_goSource, float a_fDamageToHeal)
    {
        
        if (HitPoints + a_fDamageToHeal > MaxHitPoints)
        {
            HitPoints = MaxHitPoints;
        }
        else
        {
            HitPoints += a_fDamageToHeal;
        }
    }

    void DeathCheck(GameObject a_goSource)
    {
        if (HitPoints <= 0)
        {
            if (gameObject.GetComponent<PlayerManager>())
            {
                gameObject.GetComponent<PlayerManager>().Death(a_goSource);
            }
        }
    }


}
