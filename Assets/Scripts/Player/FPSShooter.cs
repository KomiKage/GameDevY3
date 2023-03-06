using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSShooter : MonoBehaviour
{
    public Camera cam;
    public GameObject proj;
    public GameObject shield;
    public Transform firePoint;
    public Transform shieldPoint;

    private float projSpeed = 30f;
    private float TTF;
    public float fireRate = 4;
    public float arcRange = 1;
    private float spellCost = 0.08f;
    private float shieldCost = 0.1f;

    private Vector3 destination;

    public Slider manaSlider;
    public float mana = 1;

    public bool wandEnabled = false;
    private GameObject shieldObj;

    private void Start()
    {
        InvokeRepeating("ManaRecharge", 0.25f, 0.25f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= TTF)
        {
            TTF = Time.time + 1 / fireRate;
            shootProj();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            shieldCounter();
        }

        manaSlider.value = mana;
        if (mana > 1) { mana = 1; }
    }

    void shootProj()
    {
        if (mana >= spellCost && wandEnabled)
        {
            mana = mana - spellCost;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                destination = hit.point;
            else
                destination = ray.GetPoint(1000);

            instantiateProj();
        }
    }

    void shieldCounter()
    {
        if (mana >= shieldCost && wandEnabled)
        {
            shieldObj = Instantiate(shield, shieldPoint.position, cam.transform.rotation) as GameObject;
            StartCoroutine(shieldDestroy());
        }
    }

    void instantiateProj()
    {
        var projObj = Instantiate(proj, firePoint.position, Quaternion.identity) as GameObject;
        projObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projSpeed;
        iTween.PunchPosition(projObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange), 0), Random.Range(0.5f, 2));
    }

    void ManaRecharge()
    {
        mana = mana + 0.0125f;
    }

    IEnumerator shieldDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(shieldObj);
    }
}
