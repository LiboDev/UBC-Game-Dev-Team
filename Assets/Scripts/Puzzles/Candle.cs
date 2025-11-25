using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable {
    public MonoBehaviour ConnectedMechanism;
    public InteractButton InteractButton;
    public bool Interacted = false;

    public void Interact() {
        Interacted = true;
        if (ConnectedMechanism != null) {
            IMechanism mechanism = ConnectedMechanism as IMechanism;
            mechanism.Activate();
        }
        print("Interacted");
    }

    public InteractButton GetInteractButton() {
        return InteractButton;
    }

    public bool HasInteracted() {
        return Interacted;
    }
}
