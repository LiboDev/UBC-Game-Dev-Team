using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : MonoBehaviour, IMechanism {
    public Transform SideDoor1;
    public Transform SideDoor2;

    Vector3 SideDoor1DefaultPos;
    Vector3 SideDoor2DefaultPos;

    public float DoorSpeed = 1.0f;

    // How far the doors will slide open
    public float SideDoorMovementRange = 1.5f;

    public bool IsActivated = false;
    public bool IsOpening = false;

    void Start()
    {
        SideDoor1DefaultPos = SideDoor1.localPosition;
        SideDoor2DefaultPos = SideDoor2.localPosition;
    }

    void Update() {
        if (IsActivated) {
            MoveDoors();
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

    private void MoveDoors() {
        if (IsOpening) {
            MoveDoor(SideDoor1, -1, SideDoor1DefaultPos - new Vector3(SideDoorMovementRange, 0, 0));
            MoveDoor(SideDoor2, 1, SideDoor2DefaultPos + new Vector3(SideDoorMovementRange, 0, 0));
        } else {
            MoveDoor(SideDoor1, 1, SideDoor1DefaultPos);
            MoveDoor(SideDoor2, -1, SideDoor2DefaultPos);
        }
    }

    // dir should be either -1 or 1
    private void MoveDoor(Transform obj, int dir, Vector3 goal) {
        obj.localPosition += new Vector3(dir, 0, 0) * DoorSpeed * Time.deltaTime;

        if ((obj.localPosition.x - goal.x) * dir >= 0) {
            obj.localPosition = goal;
            IsActivated = false;
        }
    }
}
