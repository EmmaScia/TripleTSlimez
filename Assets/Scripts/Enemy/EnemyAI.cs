using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float maxHealth = 150f;
    [SerializeField] private float attackRange = 1.8f;
    [SerializeField] private float attackDamage = 50f;
    [SerializeField] private float attackCooldown = 1.2f;

    private float currentHealth;
    private float attackTimer;
    private NavMeshAgent agent;
    private Transform player;
    private PlayerHealth playerHealth;
    private bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackRange - 0.3f;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            playerHealth = playerObj.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogError("EnemyAI: No GameObject found with tag 'Player'. Set the Player tag in the Inspector.");
        }
    }

    void Update()
    {
        if (isDead || player == null) return;

        agent.SetDestination(player.position);

        attackTimer -= Time.deltaTime;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && attackTimer <= 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        attackTimer = attackCooldown;
        playerHealth?.TakeDamage(attackDamage);
        GetComponent<EnemyAnimator>()?.TriggerAttack();
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        if (currentHealth <= 0f)
            Die();
    }

    private void Die()
    {
        isDead = true;
        agent.enabled = false;
        RoundManager.Instance?.OnEnemyDied();
        Destroy(gameObject, 0.1f);
    }

    private void OnDestroy()
    {
        if (!isDead)
            RoundManager.Instance?.OnEnemyDied();
    }
}
