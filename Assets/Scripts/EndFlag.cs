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
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(nestSceneName);
            }
        }

    }
}
