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
        SideDoor1DefaultPos = SideDoor1.position;
        SideDoor2DefaultPos = SideDoor2.position;
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

    void MoveSideDoor1() {
        if (IsOpening) {
            if (SideDoor1.position.x > SideDoor1DefaultPos.x - SideDoorMovementRange) {
                SideDoor1.position = SideDoor1.position - new Vector3(1, 0, 0) * Time.deltaTime;
            } else {
                SideDoor1.position = SideDoor1DefaultPos - new Vector3(SideDoorMovementRange, 0, 0);
                IsActivated = false;
            }
        } else {
            if (SideDoor1.position.x < SideDoor1DefaultPos.x) {
                SideDoor1.position = SideDoor1.position + new Vector3(1, 0, 0) * Time.deltaTime;
            } else {
                SideDoor1.position = SideDoor1DefaultPos;
                IsActivated = false;
            }
        }
    }

    void MoveSideDoor2() {
        if (IsOpening) {
            if (SideDoor2.position.x < SideDoor2DefaultPos.x + SideDoorMovementRange) {
                SideDoor2.position = SideDoor2.position + new Vector3(1, 0, 0) * Time.deltaTime;
            } else {
                SideDoor2.position = SideDoor2DefaultPos + new Vector3(SideDoorMovementRange, 0, 0);
                IsActivated = false;
            }
        } else {
            if (SideDoor2.position.x > SideDoor2DefaultPos.x) {
                SideDoor2.position = SideDoor2.position - new Vector3(1, 0, 0) * Time.deltaTime;
            } else {
                SideDoor2.position = SideDoor2DefaultPos;
                IsActivated = false;
            }
        }
    }
}
