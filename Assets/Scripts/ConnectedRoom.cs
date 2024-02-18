using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectedRoom : MonoBehaviour
{
    [SerializeField]
    string SceneToTransistionTo;
    [SerializeField]
    GameObject DestinationPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = DestinationPosition.transform.position;
        SceneManager.LoadScene(SceneToTransistionTo, LoadSceneMode.Single);
    }

}
