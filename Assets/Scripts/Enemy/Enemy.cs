using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Setting")]
    //[SerializeField] private float moveSpeed = 2f;
    public EnemyHealthBar HealthBar;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackRate = 2f;
    private int currentHealth;
    public GameObject player;
    private float nextAttackTime = 0f;
    public Animator animator;
    public int maxHealth = 40;

    public float distance;
    private Transform playerPos;
    private Vector2 currentPos;
    public Transform attackPos;
    
    public float attackRange;
    public LayerMask whatIsEnemies;


    private static readonly int Hurt = Animator.StringToHash("Hurt");
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        HealthBar.SetHealth(currentHealth,maxHealth);

    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth,maxHealth);
        animator.SetTrigger(Hurt);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        int moneyDrop = Random.Range(10, 30);
        Debug.Log("Enemy died");
        animator.SetBool(IsDead,true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        QuestManager.Instance.AddProgress("KillBoar25",1);
        MoneyManager.Instance.AddMoney(moneyDrop);
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Atk();
            nextAttackTime = Time.time + 1f / attackRate;
        }
        
    }

    void Atk()
    {
        //animator.SetTrigger(Attack);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        foreach (Collider2D player in hitEnemies)  
        {
            Debug.Log("Hit Player");
            player.GetComponent<PlayerHealth>().takeDamage(attackDamage);
        }
    }
    public void OnDrawGizmosSelected()
    {
        if (attackPos == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    
    
    
}
