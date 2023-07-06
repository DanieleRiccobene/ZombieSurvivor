using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidBody;

    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();   
    }

    private void Start()
    {
        float speed = 50f;
        bulletRigidBody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.GetComponent<BulletTarget>() != null)
        {
            //hit the target
        }
        else
        {
            //hit other object
        }
        Destroy(this.gameObject);
    }
}
