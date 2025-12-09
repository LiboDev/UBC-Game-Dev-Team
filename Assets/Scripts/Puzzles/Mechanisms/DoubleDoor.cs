using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : MonoBehaviour, IMechanism {
    public Transform SideDoor1;
    public Transform SideDoor2;

    Vector3 SideDoor1DefaultPos;
    Vector3 SideDoor2DefaultPos;

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

    void MoveDoors() {
        MoveSideDoor1();
        MoveSideDoor2();
    }

    // dir should be -1 or 1
    public void MoveDoor(Transform obj, int dir, Vector3 goal) {
        obj.localPosition += new Vector3(1 * dir, 0, 0) * Time.deltaTime;
    }

    void MoveSideDoor1() {
        if (IsOpening) {
            if (SideDoor1.localPosition.x > SideDoor1DefaultPos.x - SideDoorMovementRange) {
                SideDoor1.localPosition = SideDoor1.localPosition - new Vector3(1, 0, 0) * Time.deltaTime;
            } else {
                SideDoor1.localPosition = SideDoor1DefaultPos - new Vector3(SideDoorMovementRange, 0, 0);
                IsActivated = false;
            }
        } else {
            if (SideDoor1.localPosition.x < SideDoor1DefaultPos.x) {
                SideDoor1.localPosition = SideDoor1.localPosition + new Vector3(1, 0, 0) * Time.deltaTime;
            } else {
                SideDoor1.localPosition = SideDoor1DefaultPos;
                IsActivated = false;
            }
        }
    }

    void MoveSideDoor2() {
        if (IsOpening) {
            if (SideDoor2.localPosition.x < SideDoor2DefaultPos.x + SideDoorMovementRange) {
                SideDoor2.localPosition = SideDoor2.localPosition + new Vector3(1, 0, 0) * Time.deltaTime;
            } else {
                SideDoor2.localPosition = SideDoor2DefaultPos + new Vector3(SideDoorMovementRange, 0, 0);
                IsActivated = false;
            }
        } else {
            if (SideDoor2.localPosition.x > SideDoor2DefaultPos.x) {
                SideDoor2.localPosition = SideDoor2.localPosition - new Vector3(1, 0, 0) * Time.deltaTime;
            } else {
                SideDoor2.localPosition = SideDoor2DefaultPos;
                IsActivated = false;
            }
        }
    }
}
