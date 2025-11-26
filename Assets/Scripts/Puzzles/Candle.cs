using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable {
    public MonoBehaviour ConnectedMechanism;
    public InteractButton InteractButton;

    private bool TurnedOn = false;

    public void Interact() {
        if (ConnectedMechanism != null) {
            IMechanism mechanism = ConnectedMechanism as IMechanism;

            if (TurnedOn) {
                mechanism.ToggleOff();
            } else {
                mechanism.ToggleOn();
            }
            TurnedOn = !TurnedOn;
        }
        print("Interacted");
    }

    public InteractButton GetInteractButton() {
        return InteractButton;
    }
}
