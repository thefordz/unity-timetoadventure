using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int vitality = 100; // Maximum life.
    public int health = 0;     // Current life.

    [HideInInspector] public bool isDead = false;
    [HideInInspector] public bool isHurting = false;

    private Animator animator;

    // We created a delegate to determine when to update the life bar.
    public delegate void TakeHealth(int amount);
    public TakeHealth HealthEvent;


    private void Awake()
    {
        animator = GetComponent<Animator>();

        // Set health.
        health = vitality;
    }

    public void TakeDamage(int amount)
    {
        // If the damage is positive, do not continue.
        if (health - amount > health) return;

        // Apply damage.
        health -= amount;

        // If health reaches zero, it dies.
        if (health <= 0)
        {
            health = 0;

            Death();
        }
        // Otherwise, it is a wound.
        else
        {
            Hurt(true);
        }

        LaunchHealthEvent();
    }

    public void Heal(int amount)
    {
        // If the cure is negative, do not continue.
        if (health + amount < health) return;

        // Apply cure.
        health += amount;

        if (health > vitality)
        {
            health = vitality;
        }

        LaunchHealthEvent();
    }

    public void Hurt(bool h)
    {
        // We determine that he is injured.
        isHurting = h;

        // if (h) animator.Play("Hurt");
        //
        // animator.SetBool("IsHurting", isHurting);
    }

    public void Death()
    {
        // Determine that he is dead.
        isDead = true;

        animator.SetBool("IsDead", isDead);

        GetComponent<Collider2D>().enabled = false;
    }

    public void LaunchHealthEvent()
    {
        // Update life bar.
        if (HealthEvent != null)
            HealthEvent(health);
    }

    public void StopHurt()
    {
        // Animation event to finish hurting.
        Hurt(false);
    }
}
