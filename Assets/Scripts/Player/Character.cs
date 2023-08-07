using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterHealth CharacterHealth { get;private set; }
    // Start is called before the first frame update
    void Awake()
    {
        CharacterHealth = GetComponent<CharacterHealth>();
    }

    public void RestoreCharacter()
    {
        CharacterHealth.RestoreCharacter();
    }
    
    
}
