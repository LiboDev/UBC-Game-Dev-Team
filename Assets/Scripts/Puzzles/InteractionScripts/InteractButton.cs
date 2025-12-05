using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractButton : MonoBehaviour {
    public Camera Cam;
    public GameObject Canvas;
    public float ScaleFactor = 1f;
    public TextMeshProUGUI BottomText;

    void Start() {
        if (Cam == null) {
            Cam = Camera.main;
        }
    }

    private void LateUpdate() {
        // change scale based on dist
        float dist = Vector3.Distance(transform.position, Cam.transform.position);
        transform.localScale = Vector3.one * dist * ScaleFactor;

        // make button always look at screen
        transform.LookAt(Cam.transform.position);
        transform.Rotate(0, 180, 0);
    }

    public void SetBottomText(string text) {
        BottomText.text = text;
    }

    public string GetBottomText() {
        return BottomText.text;
    }

    public void ShowButton() {
        Canvas.SetActive(true);
    }

    public void HideButton() {
        Canvas.SetActive(false);
    }
}
