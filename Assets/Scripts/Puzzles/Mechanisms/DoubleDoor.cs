using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : MonoBehaviour, IMechanism {
    public Transform SideDoor1;
    public Transform SideDoor2;

    Vector3 SideDoor1DefaultPos;
    Vector3 SideDoor2DefaultPos;

    // How far the doors will open
    public float SideDoorMovementRange = 1.5f;

    Coroutine MyTween;

    public bool IsMoving = false;
    public bool IsOpening = false;

    // time to open door as well as close door
    float TimeToOpen = 2;
    float CurrentTime = 0f;

    void Start()
    {
        SideDoor1DefaultPos = SideDoor1.position;
        SideDoor2DefaultPos = SideDoor2.position;
    }

    void Update() {
        MoveDoors();
    }

    public void ToggleOn() {
        IsOpening = true;
    }

    public void ToggleOff() {
        IsOpening = false;
    }

    public void OpenDoors() {
        StartTween(SideDoor1, SideDoor1.position, SideDoor1.transform.position - new Vector3(1, 0, 0), TimeToOpen - CurrentTime);
        StartTween(SideDoor2, SideDoor2.position, SideDoor2.transform.position + new Vector3(1, 0, 0), TimeToOpen - CurrentTime);
    }

    void StartTween(Transform obj, Vector3 startPos, Vector3 endPos, float duration) {
        MyTween = StartCoroutine(MoveOverTime(obj, startPos, endPos, duration));
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
            }
        } else {
            if (SideDoor1.position.x < SideDoor1DefaultPos.x) {
                SideDoor1.position = SideDoor1.position + new Vector3(1, 0, 0) * Time.deltaTime;
            } else {
                SideDoor1.position = SideDoor1DefaultPos;
            }
        }
    }

    void MoveSideDoor2() {
        if (IsOpening) {
            if (SideDoor2.position.x < SideDoor2DefaultPos.x + SideDoorMovementRange) {
                SideDoor2.position = SideDoor2.position + new Vector3(1, 0, 0) * Time.deltaTime;
            } else {
                SideDoor2.position = SideDoor2DefaultPos + new Vector3(SideDoorMovementRange, 0, 0);
            }
        } else {
            if (SideDoor2.position.x > SideDoor2DefaultPos.x) {
                SideDoor2.position = SideDoor2.position - new Vector3(1, 0, 0) * Time.deltaTime;
            } else {
                SideDoor2.position = SideDoor2DefaultPos;
            }
        }
    }

    void StopTween() {
        if (MyTween != null) {
            StopCoroutine(MyTween);
            MyTween = null;
        }
    }

    IEnumerator MoveOverTime(Transform obj, Vector3 startPos, Vector3 endPos, float duration) {
        float t = 0f;
        
        while (t < 1f) {
            t += Time.deltaTime / duration;
            CurrentTime = Mathf.Clamp(t, 0, TimeToOpen);
            obj.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
    }
}
