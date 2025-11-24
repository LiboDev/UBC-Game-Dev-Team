using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable
{
    public InteractButton InteractButton;
    public void Interact() {
        print("Interacted");
    }

    public InteractButton GetInteractButton() {
        return InteractButton;
    }
}
