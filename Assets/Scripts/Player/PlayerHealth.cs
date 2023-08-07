using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] protected float currenyHealth;
    [SerializeField] protected float maxHealth;
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    public float Health { get;protected set; }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Health = currenyHealth;
    }

    public void takeDamage(float amount)
    {
        if (amount <= 0 )
        {
            return;
        }

        if (Health > 0f)
        {
            Health -= amount;
            UpdateHealthBar(Health, maxHealth);
            if (Health <= 0f)
            {
                Health = 0;
                UpdateHealthBar(Health, maxHealth);
                CharacterDeath();
            }
        }
    }

    protected virtual void UpdateHealthBar(float updateHealth, float maxHealth)
    {
        
    }

    protected virtual void CharacterDeath()
    {

    }
}
