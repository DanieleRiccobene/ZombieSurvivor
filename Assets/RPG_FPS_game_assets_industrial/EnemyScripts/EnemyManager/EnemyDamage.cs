using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    private int round;
    private int HP = 100;
    public Slider healtbar;
    public Animator animator;
    private Enemy enemy;
    

    private void Start()
    {
        round = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().round;
        enemy = GetComponent<Enemy>();
    }

    public void Update()
    {
        healtbar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        if (round == 1) HP -= damageAmount;
        else if(round==2) HP -= damageAmount/2;
        else if(round==3) HP -= damageAmount/4;


        if (HP == 0)
        {
            enemy.notFollow();
            animator.SetTrigger("die");
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().reduceZombiesLeft();
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