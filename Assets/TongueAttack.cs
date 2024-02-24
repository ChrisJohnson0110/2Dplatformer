using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueAttack : MonoBehaviour
{

    public float speed = 5f; // Adjust the overall speed of the projectile
    public float amplitude = 5f; // Adjust the amplitude of the projectile's movement

    private float startTime;
    private Vector2 initialLocalPosition;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        initialLocalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        //if tongue attack
        //get dir on first use

        float timePassed = Time.time - startTime;
        float displacement = amplitude * Mathf.Sin(timePassed * speed);

        //change displacement value to be position or negative depending on desired direction 
        //get parent dir
        //use math approx to get if tongue has returned
        //set inactive

        Vector2 newLocalPosition = initialLocalPosition + Vector2.right * displacement;
        transform.localPosition = Vector2.Lerp(transform.localPosition, newLocalPosition, Time.deltaTime * speed);

    }
}
