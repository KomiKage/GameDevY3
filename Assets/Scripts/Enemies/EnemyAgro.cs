    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    public EnemyTestShoot agro;

    private void Start()
    {
        //agro = GetComponent<EnemyTestShoot>();
    }

    private void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.CompareTag("Player"))
        {
            Debug.Log("ploop");
            agro.enabled = true;
        }
    }
}
