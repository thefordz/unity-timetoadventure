using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionExtraNPC
{
    Quest,
    Trade,
    Crafing
}
[CreateAssetMenu]
public class NPCDialog : ScriptableObject
{
    [Header("Info")] 
    public string Name;
    public Sprite Icon;
    public bool ContainerInteractionExtra;
    public InteractionExtraNPC InteractionExtra;

    [Header("Greeting")] 
    [TextArea] public string Greeting;

    [Header("Chat")] 
    public DialogText[] Conversation;
    
    [Header("Description")] 
    [TextArea] public string Farewell;
}

[Serializable]
public class DialogText
{
    [TextArea] public string Prayer;
}