using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null; // the interactable object currently in range
    public GameObject interactionIcon; // UI icon to show when you can interact

    void Start()
    {
        if (interactionIcon != null)
            interactionIcon.SetActive(false);
    }

    void Update()
    {
        // Check if player presses E while in range
        if (interactableInRange != null && Input.GetKeyDown(KeyCode.E))
        {
            interactableInRange.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object has an IInteractable component and can be interacted with
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            interactableInRange = interactable;

            if (interactionIcon != null)
                interactionIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // When leaving the interactable area, remove reference
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;

            if (interactionIcon != null)
                interactionIcon.SetActive(false);
        }
    }


}
