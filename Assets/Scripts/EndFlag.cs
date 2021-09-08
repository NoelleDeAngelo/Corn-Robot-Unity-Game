using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public string nestSceneName;
    public bool lastLevel;

    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(lastLevel)
            {
                Debug.Log("you win");
            }
            else
            {
                SceneManager.LoadScene(nestSceneName);
            }
        }

    }
}
