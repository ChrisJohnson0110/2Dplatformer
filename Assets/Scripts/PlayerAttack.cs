using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public InputController input = null;

    [SerializeField] GameObject goBulletPrefab;
    [SerializeField] int iNumberOfBulletsToCreate;
    [SerializeField] float fAttackSpeedBase;
    [SerializeField] float fAttackDamageBase;

    List<GameObject> bullets;

    float fAttackSpeed;
    float fAttackDamage;
    float AttackSpeedModifier;
    float AttackDamageModifier;

    [SerializeField] float spitAttackDelayStarting = 2f;
    float spitAttackDelay;
    [SerializeField] float tongueAttackDelayStarting = 2f;
    float tongueAttackDelay;
    
    [Header("Tongue")]
    public GameObject projectilePrefab;
    //GameObject projectile = null;
    [SerializeField] float TongueSpeed = 30f;
    [SerializeField] float TongueRange = 5f;

    bool isFacingRight = true;


    void TongueProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        //set tongue properties
        TongueAttack projectileController = projectile.GetComponent<TongueAttack>();
        
        if (projectileController != null)
        {
            projectileController.speed = TongueSpeed;
            projectileController.range = TongueRange;
            projectileController.returningProjectile = false;
            projectileController.isFacingRight = isFacingRight;
        }
    }

    private void Awake()
    {
        spitAttackDelay = spitAttackDelayStarting;
        tongueAttackDelay = tongueAttackDelayStarting;

        bullets = new List<GameObject>();
        for (int i = 0; i < iNumberOfBulletsToCreate; i++)
        {
            bullets.Add(Instantiate(goBulletPrefab));
            bullets[i].SetActive(false);
        }
        GetAttackProperties();
        SetAttackProperties();
    }


    private void Update()
    {
        if (input.RetrieveMoveInput() == -1)
        {
            isFacingRight = false;
        }
        else if (input.RetrieveMoveInput() == 1)
        {
            isFacingRight = true;
        }
    }


    //update the values in this script that represent the power ups obtained
    public void GetAttackProperties()
    {
        AttackSpeedModifier = 0;
        //AttackSpeedModifier += ; //add skills
        //AttackSpeedModifier += ; //add charms
        //AttackSpeedModifier += ; //add player effects

        AttackDamageModifier = 0;
        //AttackDamageModifier += ; //add skills
        //AttackDamageModifier += ; //add charms
        //AttackDamageModifier += ; //add player effects

        fAttackSpeed = fAttackSpeedBase + AttackSpeedModifier;
        fAttackDamage = fAttackDamageBase + AttackDamageModifier;
    }

    //apply the powerups to the bullets
    public void SetAttackProperties()
    {
        foreach (GameObject go in bullets)
        {
            go.GetComponent<ProjectileProperties>().fSpeed = fAttackSpeed;
            go.GetComponent<ProjectileProperties>().fDamage = fAttackDamage;
        }
    }


    public void Attack()
    {
        TongueAttack();
        SpitAttack();
    }

    public void TongueAttack()
    {
        if (tongueAttackDelay <= 0)
        {
            if (input.RetrieveAttackInputOne() == true)
            {
                TongueProjectile();
                tongueAttackDelay = tongueAttackDelayStarting;
            }
        }
        tongueAttackDelay -= Time.deltaTime;
    }

    void SpitAttack()
    {
        if (spitAttackDelay <= 0)
        {
            if (input.RetrieveAttackInputTwo() == true)
            {
                GameObject AttackToUse = null;
                foreach (GameObject go in bullets)
                {
                    if (go.activeSelf == false)
                    {
                        AttackToUse = go;
                        break;
                    }
                }

                if (AttackToUse == null)
                {
                    return;
                }

                AttackToUse.transform.position = this.transform.position;

                AttackToUse.GetComponent<ProjectileProperties>().isFacingRight = isFacingRight;

                AttackToUse.SetActive(true);
                spitAttackDelay = spitAttackDelayStarting;
            }
        }
        spitAttackDelay -= Time.deltaTime;
    }

}
