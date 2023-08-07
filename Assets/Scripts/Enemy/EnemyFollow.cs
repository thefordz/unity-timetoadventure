using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;

    public float speed;

    private float distance;

    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        

        transform.position =
            Vector2.MoveTowards(this. transform.position, player.transform.position, speed * Time.deltaTime);

        _animator.SetBool("IsRun", true);
        if (distance < 4)
        {
            transform.position =
                Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
