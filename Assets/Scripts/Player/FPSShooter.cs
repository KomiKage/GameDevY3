using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSShooter : MonoBehaviour
{
    public Camera cam;
    public GameObject proj;
    public Transform firePoint;

    private float projSpeed = 30f;
    private float TTF;
    public float fireRate = 4;
    public float arcRange = 1;

    private Vector3 destination;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= TTF)
        {
            TTF = Time.time + 1 / fireRate;
            shootProj();
        }
    }

    void shootProj()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);

        instantiateProj();
    }

    void instantiateProj()
    {
        var projObj = Instantiate(proj, firePoint.position, Quaternion.identity) as GameObject;
        projObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projSpeed;
        iTween.PunchPosition(projObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));
    }
}
