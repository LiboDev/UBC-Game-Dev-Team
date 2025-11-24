using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour {
    public Camera cam;
    public GameObject canvas;
    public float scaleFactor = 1f;

    void Start() {
        if (cam == null) {
            cam = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() {
        // change scale based on dist
        float dist = Vector3.Distance(transform.position, cam.transform.position);
        transform.localScale = Vector3.one * dist * scaleFactor;

        // make button always look at screen
        transform.LookAt(cam.transform.position);
        transform.Rotate(0, 180, 0);
    }

    public void ShowButton() {
        canvas.SetActive(true);
    }

    public void HideButton() {
        canvas.SetActive(false);
    }
}
