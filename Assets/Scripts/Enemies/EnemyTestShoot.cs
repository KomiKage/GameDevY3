using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestShoot : MonoBehaviour
{
    public GameObject proj;
    public Transform firePoint;

    private float projSpeed = 30f;
    private float TTF;
    public float fireRate = 0.5f;
    public float arcRange = 1;

    public Transform target;
    private float speed = 10f;

    private void Start()
    {
        StartCoroutine(enemyShoot());
    }

    private void Update()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    void instantiateProj()
    {
        var projObj = Instantiate(proj, firePoint.position, Quaternion.identity) as GameObject;
        //projObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projSpeed;
        //projObj.GetComponent<Rigidbody>().velocity = new Vector3(0,0,10) * projSpeed;
        projObj.GetComponent<Rigidbody>().AddForce(transform.forward * 100 * projSpeed);
        //iTween.PunchPosition(projObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));
    }

    IEnumerator enemyShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            instantiateProj();
        }
    }
}
