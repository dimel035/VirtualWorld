using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class playerInteractor : MonoBehaviour
{
    public float interactDistance = 3.0f;
    public Animator playerAnimator;
    [SerializeField] private ThirdPersonController thirdPersonController; 
    private IInteractable currentInteractable;
    private bool isInteracting = false;
    public Canvas interactionCanvas;
    bool interactableDetected = false;
    IInteractable interactable;

    private void Awake()
    {
        interactable = null;
    }
    void Start()
    {
        // Disable interactionCanvas initially
        interactionCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isInteracting && Input.GetKeyDown(KeyCode.E))
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
            if (currentInteractable is horse)
            {
                isInteracting = true;
                StartCoroutine(PetHorseCoroutine());
            }
        }
    }

    IEnumerator PetHorseCoroutine()
    {
        //Disable movement
        thirdPersonController.enabled = false;

        //Trigger petting animation
        playerAnimator.SetTrigger("PetHorse");

        //Wait for the duration of the petting animation
        float pettingAnimationDuration = 14.167f;
        yield return new WaitForSeconds(pettingAnimationDuration);

        //Enable movement
        thirdPersonController.enabled= true;

        //Reset interaction state
        isInteracting = false;
    }
    void CheckForHighlight()
    {
        // Raycast from the player's position forward
        Ray ray = new Ray(transform.position + Vector3.up, transform.forward); // Offset to ensure raycast starts at player's height
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red); // Draw ray in editor for debugging


        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                // Check if the detected interactable is different from the current one
                if (interactable != currentInteractable)
                {
                    // Unhighlight the current interactable if there is one
                    if (currentInteractable != null)
                    {
                        currentInteractable.Unhighlight();
                        Debug.Log("Unhighlighting previous interactable.");
                    }

                    // Update currentInteractable to the new one
                    currentInteractable = interactable;
                    currentInteractable.Highlight();
                    Debug.Log("Highlighting new interactable.");

                    // Check if the new interactable is a horse
                    if (currentInteractable is horse)
                    {
                        Debug.Log("Horse detected, enabling interactionCanvas.");
                        interactionCanvas.gameObject.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("Disabling interactionCanvas - not a horse.");
                        interactionCanvas.gameObject.SetActive(false);
                    }

                    // Set interactableDetected to true to indicate an interactable was found
                    interactableDetected = true;
                }
            }
            else
            {
                if (currentInteractable != null)
                {
                    currentInteractable.Unhighlight();
                    currentInteractable = null;
                    Debug.Log("No interactable detected, disabling interactionCanvas.");
                }
                
            }
        }
        else
        {
            interactionCanvas.gameObject.SetActive(false);
        }

    }
    
}
