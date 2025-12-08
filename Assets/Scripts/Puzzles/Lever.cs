using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable {
    public MonoBehaviour ConnectedMechanism;
    public InteractButton ButtonUI;

    public float cooldown = 1f;
    private float nextUseTime = 0f;

    private bool IsEngaged = false;

    private string TurnOnText = "Engage Lever";
    private string TurnOffText = "Disengage Lever";
    public void Update() {
        if (IsEngaged) {
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
            if (Time.time >= nextUseTime) {
                IMechanism mechanism = ConnectedMechanism as IMechanism;

                if (IsEngaged) {
                    mechanism.ToggleOff();
                } else {
                    mechanism.ToggleOn();
                }
                IsEngaged = !IsEngaged;

                nextUseTime = Time.time + cooldown;
            }
        }
    }

    IEnumerator RotateOverTime(Transform obj, Quaternion startRot, Quaternion endRot, float duration) {
        float t = 0f;

        while (t < 1f) {
            t += Time.deltaTime / duration;
            obj.rotation = Quaternion.Lerp(startRot, endRot, t);
            yield return null;
        }

        obj.rotation = endRot;
    }

    public InteractButton GetInteractButton() {
        return ButtonUI;
    }
}
