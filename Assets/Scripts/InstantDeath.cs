using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantDeath : MonoBehaviour
{

    private void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.CompareTag("Player"))
        {
            Debug.Log("yuck");
            SceneManager.LoadSceneAsync(2);
        }
    }

}
