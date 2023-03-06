using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestShoot : MonoBehaviour
{
    public GameObject proj;
    public Transform firePoint;

    private float projSpeed = 30f;
    private float TTF;
    public float fireRate = 4;
    public float arcRange = 1;

    private void Start()
    {
        StartCoroutine(enemyShoot());
    }

    void instantiateProj()
    {
        var projObj = Instantiate(proj, firePoint.position, Quaternion.identity) as GameObject;
        //projObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projSpeed;
        projObj.GetComponent<Rigidbody>().velocity = new Vector3(0,0,10) * projSpeed;
        //iTween.PunchPosition(projObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));
    }

    IEnumerator enemyShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            instantiateProj();
        }
    }
}
