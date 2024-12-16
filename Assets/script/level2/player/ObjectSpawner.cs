using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject objectPrefab; // modelo de la bala
    public float bulletForce;  // fuerza con la que sale 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameObject bulletClone = Instantiate(objectPrefab, transform.position, transform.rotation); // el nuevo clon de la bala

            Rigidbody bulletRigidBody = bulletClone.GetComponent<Rigidbody>(); // el rigid body de la nueva bala

            bulletRigidBody.velocity = transform.up * bulletForce; // el impulso multiplicado por el bullet force

            Destroy(bulletClone, 2f);

        }
    }
}
