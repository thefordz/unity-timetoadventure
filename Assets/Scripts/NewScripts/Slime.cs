using UnityEngine;

public class Slime : MonoBehaviour
{
    private HealthController health;
    private AttackController attack;
    private PingPongMovement movement;
    public float attackDamage;
    private Animator animator;

    private bool isWalking = false;

    private float speed = 0f; // Movement speed.

    private static readonly int Hurt = Animator.StringToHash("Hurt");
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private static readonly int IsRun = Animator.StringToHash("IsRun");

    private void Awake()
    {
        //health = GetComponent<HealthController>();
        //attack = GetComponent<AttackController>();
        movement = GetComponent<PingPongMovement>();
        animator = GetComponent<Animator>();

        // We set the speed of movement.
        speed = movement.speed;
    }

    private void FixedUpdate()
    {
        movement.speed = isWalking ? speed : 0;

        animator.SetBool(IsRun, isWalking);

        // If can´t walk...
        if (health.isDead || health.isHurting || movement == null)
        {
            // Stop.
            isWalking = false;

            return;
        }

        // Stay still while attacking.
        if (attack.isAttacking)
        {
            isWalking = false;
        }
        // Check if the player is in your attack range.
        else
        {
            // Get a list with all enemies within range.
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attack.attackPoint.position, attack.range, attack.whatIsEnemy);

            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                // If you find the player in that list...
                if (enemiesToDamage[i].tag == "Player")
                {
                    // And he is not dead...
                    // if (!enemiesToDamage[i].GetComponent<HealthController>().isDead)
                    //     // Attack.
                    //     attack.Attack(true);
                    foreach (Collider2D player in enemiesToDamage)
                    {
                        Debug.Log("Hit Player");
                        player.GetComponent<PlayerHealth>().takeDamage(attackDamage);
                    }
                    
                    
                }
            }

            // While doing all this, you can walk.
            isWalking = true;
        }
        

    }
}
