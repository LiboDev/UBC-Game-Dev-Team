using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoor : MonoBehaviour, IMechanism {
    public Transform Door;

    Vector3 DoorDefaultPos;

    public float DoorSpeed = 1.0f;

    // How far the door will slide open
    public float DoorMovementRange = 3.5f;

    public bool IsActivated = false;
    public bool IsOpening = false;

    void Start() {
        DoorDefaultPos = Door.localPosition;
    }

    void Update() {
        if (IsActivated) {
            MoveDoor();
        }
    }

    public void ToggleOn() {
        IsOpening = true;
        IsActivated = true;
    }

    public void ToggleOff() {
        IsOpening = false;
        IsActivated = true;
    }

    private void MoveDoor() {
        int dir = IsOpening ? 1 : -1;

        Door.localPosition = new Vector3(0, Mathf.Clamp(Door.localPosition.y + dir * Time.deltaTime * DoorSpeed, DoorDefaultPos.y, DoorDefaultPos.y + DoorMovementRange), 0);

        if (Door.localPosition.y == DoorDefaultPos.y || Door.localPosition.y == DoorDefaultPos.y + DoorMovementRange) {
            IsActivated = false;
        }
    }
}