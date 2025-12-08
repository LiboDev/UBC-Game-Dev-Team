using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable {
    public MonoBehaviour ConnectedMechanism;
    public InteractButton ButtonUI;

    private bool IsLit = false;

    // text associated with turning off and on
    private string TurnOnText = "Light Candle";
    private string TurnOffText = "Extinguish Candle";

    public void Update() {
        if (IsLit) {
            if (ButtonUI.GetBottomText() != TurnOffText) {
                ButtonUI.SetBottomText(TurnOffText);
            }
        } else {
            if (ButtonUI.GetBottomText() != TurnOnText) {
                ButtonUI.SetBottomText(TurnOnText);
            }
        }
    }

    public void Interact() {
        if (ConnectedMechanism != null) {
            IMechanism mechanism = ConnectedMechanism as IMechanism;

            if (IsLit) {
                mechanism.ToggleOff();
            } else {
                mechanism.ToggleOn();
            }
            IsLit = !IsLit;
        }
    }

    public InteractButton GetInteractButton() {
        return ButtonUI;
    }
}
