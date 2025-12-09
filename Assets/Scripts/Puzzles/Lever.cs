using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable {
    public MonoBehaviour ConnectedMechanism;
    public InteractButton ButtonUI;
    public Transform StickPivot;

    public float cooldown = 1f;
    private float nextUseTime = 0f;

    private float LeverRotationRange = 70f;

    private bool IsEngaged = false;

    // text associated with turning off and on
    private string TurnOnText = "Engage Lever";
    private string TurnOffText = "Disengage Lever";
    
    void Start() {
        ButtonUI.SetBottomText(TurnOnText);
    }

    public void Interact() {
        if (ConnectedMechanism != null) {
            if (Time.time >= nextUseTime) {
                StartCoroutine(RotateOverTime(StickPivot, StickPivot.rotation, Quaternion.Euler(StickPivot.eulerAngles + new Vector3(LeverRotationRange, 0, 0)), 0.5f));
                LeverRotationRange *= -1;

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

        TriggerMechanism();
    }

    private void TriggerMechanism() {
        IMechanism mechanism = ConnectedMechanism as IMechanism;

        IsEngaged = !IsEngaged;

        if (IsEngaged) {
            mechanism.ToggleOn();
        } else {
            mechanism.ToggleOff();
        }

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

    public InteractButton GetInteractButton() {
        return ButtonUI;
    }
}
