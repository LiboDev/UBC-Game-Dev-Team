using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingCubeMechanism : MonoBehaviour, IMechanism {
    public void Activate() {
        transform.localScale = transform.localScale * 3;
    }
}
