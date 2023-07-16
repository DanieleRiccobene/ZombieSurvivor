using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damageAmount = 20;
    
    void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.GetComponent<Rigidbody>());
        
        if(other.tag == "Zombie")
        {
            other.GetComponent<EnemyDamage>().TakeDamage(damageAmount);
        }
    }
}
