using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    private int HP = 100;
    public Slider healtbar;
    public Animator animator;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    public void Update()
    {
        healtbar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP = HP - damageAmount;

        if(HP == 0)
        {
            enemy.notFollow();
            animator.SetTrigger("die");
            Destroy(GetComponent<ZombieBehavior>());
            StartCoroutine(DestroyEnemy());
        }
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(4);
        
        Destroy(this.gameObject);
    }
}
