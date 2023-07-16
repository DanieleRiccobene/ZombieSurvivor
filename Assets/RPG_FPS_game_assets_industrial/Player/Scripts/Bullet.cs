using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damageAmount = 20;
    private Rigidbody bulletRigidBody;

    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 100f;
        bulletRigidBody.velocity = transform.forward * speed;
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            Destroy(this.gameObject);
            other.GetComponent<EnemyDamage>().TakeDamage(damageAmount);
        }
    }
}
