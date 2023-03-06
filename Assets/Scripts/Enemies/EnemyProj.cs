using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProj : MonoBehaviour
{
    private bool collided = false;
    private float lifetime = 5f;
    private float projSpeed = 30f;

    private void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag != "Bullet" && co.gameObject.tag != "Enemy" && !collided)
        {
            if (co.gameObject.tag == "Shield")
            {
                Debug.Log("Countered!");
                var velo = gameObject.GetComponent<Rigidbody>().velocity;
                var opp = -velo;
                velo = opp * projSpeed;
                //Destroy(gameObject);
            }
            else
            {
                collided = true;
                Destroy(gameObject);
            }
        }

    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
