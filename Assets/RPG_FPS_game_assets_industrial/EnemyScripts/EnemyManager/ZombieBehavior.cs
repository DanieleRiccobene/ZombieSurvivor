using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehavior : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocit� di movimento degli zombie
    public float chaseSpeed = 6f; // Velocit� di inseguimento degli zombie
    public float chaseDistance = 10f; // Distanza di rilevamento del giocatore
    public float attackDistance = 2f; //Distance di attacco dello zombie
    public int damage = 5;

    public bool isChasing = false; // Flag per indicare se lo zombie sta inseguendo il giocatore
    private bool isAttacking = false; //Flag per indicare se lo zombie sta attaccando
    private Vector3 randomDirection; // Direzione casuale di movimento
    private HealthBar healthBar;
    private GameObject playerController;
    private Transform player;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        // Avvia le coroutine
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(ZombieMovementCoroutine());
        StartCoroutine(PlayerDetectionCoroutine());
    }

    private IEnumerator ZombieMovementCoroutine()
    {
        while (true)
        {
            if (isChasing)
            {
                // Se lo zombie sta inseguendo il giocatore, muoviti verso di lui
                
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", false);
            }
            else if (isAttacking)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isAttacking", true);
            }
            else
            {
                // Se lo zombie non sta inseguendo il giocatore, muoviti in modo casuale
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
            }

            yield return null;
        }
    }

    public bool OnAttack()
    {
        if (isAttacking)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator PlayerDetectionCoroutine()
    {
        while (true)
        {
            // Calcola la distanza tra lo zombie e il giocatore
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= chaseDistance && distanceToPlayer >= attackDistance)
            {
                // Se il giocatore è abbastanza vicino, inizia a inseguirlo
                isChasing = true;
            }
            else if (distanceToPlayer <= attackDistance)
            {
                isChasing = false;
                isAttacking = true;
            }
            else
            {
                isChasing = false;
                isAttacking = false;
            }

            yield return null;
        }
    }
    
}
