using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour {
    [SerializeField] ChatBubble chatBubble; 

    public void Interact()
    {
        chatBubble.Create();
    }
}
