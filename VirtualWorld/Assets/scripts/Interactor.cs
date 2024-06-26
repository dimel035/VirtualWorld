
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interactDistance = 3.0f;
    private Camera mainCamera;
    private IInteractable currentInteractable;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        CheckForHighlight();
    }

    void Interact()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckForHighlight()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (interactable != currentInteractable)
                {
                    if (currentInteractable != null)
                    {
                        currentInteractable.Unhighlight();
                    }
                    currentInteractable = interactable;
                    currentInteractable.Highlight();
                }
                return;
            }
        }

        if (currentInteractable != null)
        {
            currentInteractable.Unhighlight();
            currentInteractable = null;
        }
    }
}
