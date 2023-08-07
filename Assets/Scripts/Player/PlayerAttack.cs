using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRangeX;
    public float attackRangeY;
    public LayerMask whatIsEnemies;
    public int Damage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //OnFire();
    }


    // void OnFire()
    // {
    //     
    //     if (timeBtwAttack <= 0)
    //     {
    //         print("Attack");
    //         _animator.SetTrigger("Attack");
    //             Collider2D[] enemiesToDamage =
    //                 Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX,attackRangeY),0,whatIsEnemies );
    //             for (int i = 0; i < enemiesToDamage.Length; i++)
    //             {
    //                 enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(Damage);
    //             }
    //             timeBtwAttack = startTimeBtwAttack;
    //     }
    //     else
    //     {
    //         timeBtwAttack -= Time.deltaTime;
    //     }
    // }
    //
    // public void OnDrawGizmosSelected()
    // {
    //     Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    // }

    // public void onFire()
    // {
    //     Debug.Log("Atk");
    // }

    
}
