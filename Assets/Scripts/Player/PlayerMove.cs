using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;
    
    private Rigidbody2D RB;
    public PlayerController playerController;
    private Vector2 moveInput;
    
    private Animator animator;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    
    private static readonly int Attack = Animator.StringToHash("Attack");


    //private int AnimState = Animator.StringToHash("AnimState");

    private void Awake()
    {
        playerController = new PlayerController();
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerController.PlayerMovement.Enable();
    }

    private void OnDisable()
    {
        playerController.PlayerMovement.Disable();
    }
    
    private void FixedUpdate()
    {
        OnMove();
    }

    void OnMove()
    {
        moveInput = playerController.PlayerMovement.Move.ReadValue<Vector2>();
        moveInput.y = 0f;
        RB.velocity = moveInput * moveSpeed;

        Vector3 characterScale = transform.localScale;
        
         if(moveInput.x > 0)
        {
            animator.SetBool("Run", true);
            characterScale.x = 1;
        }
         else if (moveInput.x < 0)
         {
             animator.SetBool("Run", true);
             characterScale.x = -1;
         }
         else
         {
             animator.SetBool("Run", false);
         }
         
         transform.localScale = characterScale;
         
    }

    void OnFire()
    {
        if (Time.time >= nextAttackTime)
        {
            Atk();
            nextAttackTime = Time.time + 1f / attackRate;
        }
        
    }

    void Atk()
    {
        animator.SetTrigger(Attack);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        foreach (Collider2D enemy in hitEnemies)  
        {
            Debug.Log("Hit "+ enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
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
