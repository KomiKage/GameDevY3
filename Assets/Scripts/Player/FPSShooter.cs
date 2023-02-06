using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSShooter : MonoBehaviour
{
    public Camera cam;
    public GameObject proj;
    public Transform firePoint;

    private float projSpeed = 30f;

    private Vector3 destination;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
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
    }
}
