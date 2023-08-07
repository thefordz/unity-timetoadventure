using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    private Animator _animator;

    public bool EnMovement => _dirMovement.magnitude > 0f;
    public Vector2 DirMovement => _dirMovement;
    
    private Rigidbody2D _rb;
    private Vector2 _dirMovement;
    private Vector2 _input;
    private static readonly int Run = Animator.StringToHash("Run");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        //x
        if (_input.x > 0.1f)
        {
            _dirMovement.x = 1f;
            _animator.SetBool(Run,true);
        }
        else if (_input.x < 0f)
        {
            _dirMovement.x = -1f;
            _animator.SetBool(Run,true);
        }
        else
        {
            _dirMovement.x = 0f;
            _animator.SetBool(Run,false);
        }
        
        //y
        // if (_input.y > 0.1f)
        // {
        //     _dirMovement.y = 1f;
        // }
        // else if (_input.y < 0f)
        // {
        //     _dirMovement.y = -1f;
        // }
        // else
        // {
        //     _dirMovement.y = 0f;
        // }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _dirMovement * velocity * Time.fixedDeltaTime);
    }
}
