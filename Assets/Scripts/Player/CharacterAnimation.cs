using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animation _anim;
    private CharacterMovement _playerMovement;

    private void Awake()
    {
        _anim = GetComponent<Animation>();
        _playerMovement = GetComponent<CharacterMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
