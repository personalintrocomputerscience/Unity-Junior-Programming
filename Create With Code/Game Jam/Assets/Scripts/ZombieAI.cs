using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform player;

    [Header("Movement")]
    [SerializeField] private float chaseRange = 20f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float zombieSpeed = 1.2f;

    [Header("Damage")]
    [SerializeField] private float damage = 15f;
    [SerializeField] private float attackCooldown = 1.5f;

    private NavMeshAgent agent;
    private Animator animator;
    private Health playerHealth;

    private float nextAttackTime;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        if (player != null)
            playerHealth = player.GetComponent<Health>();

        if (agent != null)
        {
            agent.speed = zombieSpeed;
            agent.stoppingDistance = attackRange * 0.8f;
        }
    }

    private void Update()
    {
        if (agent == null || player == null)
            return;

        if (!agent.isOnNavMesh)
            return;

        if (playerHealth == null ||
            playerHealth.CurrentHealth <= 0f)
        {
            agent.isStopped = true;
            agent.ResetPath();

            SetWalking(false);
            return;
        }

        float distance = Vector3.Distance(
            transform.position,
            player.position
        );

        // ATTACK
        if (distance <= attackRange)
        {
            agent.isStopped = true;
            agent.ResetPath();

            SetWalking(false);

            if (Time.time >= nextAttackTime &&
                animator != null &&
                !animator.GetCurrentAnimatorStateInfo(0)
                    .IsName("Z_Attack") &&
                !animator.IsInTransition(0))
            {
                animator.SetTrigger("Attack");

                playerHealth.TakeDamage(damage);

                nextAttackTime =
                    Time.time + attackCooldown;
            }
        }

        // SLOW WALK
        else if (distance <= chaseRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);

            SetWalking(true);
        }

        // IDLE
        else
        {
            agent.isStopped = true;
            agent.ResetPath();

            SetWalking(false);
        }
    }

    private void SetWalking(bool walking)
    {
        if (animator != null)
        {
            animator.SetBool("IsWalking", walking);
        }
    }
}