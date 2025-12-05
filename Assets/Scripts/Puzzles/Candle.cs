using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable {
    public MonoBehaviour ConnectedMechanism;
    public InteractButton InteractButton;

    private bool TurnedOn = false;

    // text associated with turning off and on
    private string TurnOnText = "Light Candle";
    private string TurnOffText = "Extinguish Candle";

    public void Update() {
        if (TurnedOn) {
            if (InteractButton.GetBottomText() != TurnOffText) {
                InteractButton.SetBottomText(TurnOffText);
            }
        } else {
            if (InteractButton.GetBottomText() != TurnOnText) {
                InteractButton.SetBottomText(TurnOnText);
            }
        }
    }

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
