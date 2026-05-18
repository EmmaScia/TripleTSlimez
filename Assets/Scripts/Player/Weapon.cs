using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage = 75f;
    [SerializeField] private float attackRange = 2.5f;
    [SerializeField] private float attackCooldown = 0.6f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Animator batAnimator;

    private float cooldownTimer;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public void Attack()
    {
        if (cooldownTimer > 0f) return;
        cooldownTimer = attackCooldown;

        batAnimator?.SetTrigger("Swing");

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.SphereCast(ray, 0.3f, out RaycastHit hit, attackRange))
        {
            EnemyAI enemy = hit.collider.GetComponentInParent<EnemyAI>();
            enemy?.TakeDamage(damage);
        }
    }
}
