using UnityEngine;

public class AttackController : MonoBehaviour
{
    public int damage = 10;       // Amount of damage.
    public float speed = 1f;      // Attack speed.
    public float range = 1f;      // Attack radius that takes as its center the attackPoint.
    public Transform attackPoint; // Point from which to attack.
    public LayerMask whatIsEnemy; // A mask determining what is enemy to the character.

    [HideInInspector] public bool isAttacking = false;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack(bool a)
    {
        // Determine if he is attacking.
        isAttacking = a;

        // Increase the speed of the animation based on the attack speed.
        animator.SetFloat("AttackSpeed", speed);

        animator.SetBool("IsAttacking", isAttacking);
    }

    public void Hit()
    {
        // Get a list with all enemies within range.
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPoint.position, range, whatIsEnemy);

        // Variable to save who has been the last enemy listed.
        HealthController lastEnemy = null;

        // It damages the enemies of the list.
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            // Current enemy to attack.
            HealthController enemyHealth = enemiesToDamage[i].GetComponent<HealthController>();

            if (lastEnemy != null)
            {
                //If this enemy is the same as the previous one...
                if (enemyHealth == lastEnemy)
                    //It passes to the next one.
                    continue;
            }

            if (enemyHealth != null)
                enemyHealth.TakeDamage(damage);

            // Update the value of the variable.
            lastEnemy = enemyHealth;
        }
    }

    public void StopAttack()
    {
        // Animation event to finish attacking.
        Attack(false);
    }

    // Draw the attack area.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}
