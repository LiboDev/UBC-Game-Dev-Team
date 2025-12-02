using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : MonoBehaviour, IMechanism {
    public Transform SideDoor1;
    public Transform SideDoor2;

    Coroutine MyTween;

    // time to open door as well as close door
    float TimeToOpen = 2;
    float CurrentTime = 0f;

    void Start()
    {
        
    }

    public void ToggleOn() {
        OpenDoors();
    }

    public void ToggleOff() {

    }

    public void OpenDoors() {
        StartTween(SideDoor1, SideDoor1.position, SideDoor1.transform.position - new Vector3(1, 0, 0), TimeToOpen);
        StartTween(SideDoor2, SideDoor2.position, SideDoor2.transform.position + new Vector3(1, 0, 0), TimeToOpen);
    }

    void StartTween(Transform obj, Vector3 startPos, Vector3 endPos, float duration) {
        MyTween = StartCoroutine(MoveOverTime(obj, startPos, endPos, duration));
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
            obj.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
    }
}
