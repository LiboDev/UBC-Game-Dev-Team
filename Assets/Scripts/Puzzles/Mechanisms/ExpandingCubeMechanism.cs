using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingCubeMechanism : MonoBehaviour, IMechanism {
    public void ToggleOn() {
        transform.localScale = transform.localScale * 3;
    }

    public void ToggleOff() {
        transform.localScale = transform.localScale / 3;
    }
}
