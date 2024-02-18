using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBetweenScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (this.gameObject == GameObject.FindGameObjectWithTag("Player").gameObject)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }

}
