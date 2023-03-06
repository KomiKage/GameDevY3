using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(shieldDestroy());
    }

    IEnumerator shieldDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
