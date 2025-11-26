using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripts that are triggered when the interactable is interacted with
public interface IMechanism {
    public void ToggleOn();

    public void ToggleOff();
}

interface IInteractable {
    // Interact with button press
    public void Interact();
    // Get script instance for UI button
    public InteractButton GetInteractButton();
}

public class Interactor : MonoBehaviour
{
    // The camera
    public Transform InteractorSource;
    public float InteractRange;

    // Last obj hovered over
    public GameObject lastHoveredObj;

    void Update() {
        int mask = LayerMask.GetMask("Interactable");
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange, mask)) {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
/*                if (hitInfo.collider.gameObject.GetComponent<IInteractable>().HasInteracted() == false) {

                }*/
                if (lastHoveredObj != hitInfo.collider.gameObject) {
                    if (lastHoveredObj != null) {
                        lastHoveredObj.GetComponent<IInteractable>().GetInteractButton().HideButton();
                    }

                    lastHoveredObj = hitInfo.collider.gameObject;
                    lastHoveredObj.GetComponent<IInteractable>().GetInteractButton().ShowButton();
                }

                if (Input.GetKeyDown(KeyCode.E)) {
                    interactObj.Interact();
                }
            }
        } else {
            if (lastHoveredObj != null) {
                if (lastHoveredObj != null) {
                    lastHoveredObj.GetComponent<IInteractable>().GetInteractButton().HideButton();
                }

                lastHoveredObj = null;
            }
        }
    }
}
