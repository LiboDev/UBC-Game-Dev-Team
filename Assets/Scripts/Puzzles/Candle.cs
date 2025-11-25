using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable
{
    public InteractButton InteractButton;
    public bool Interacted = false;

    public void Interact() {
        Interacted = true;
        print("Interacted");
    }

    public InteractButton GetInteractButton() {
        return InteractButton;
    }

    public bool HasInteracted() {
        return Interacted;
    }
}
