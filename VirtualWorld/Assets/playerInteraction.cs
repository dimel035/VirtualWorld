using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;

public class playerInteraction : MonoBehaviour
{
    public Camera mainCam;
    [SerializeField] Transform player;
    public float interactionDistance = 2f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    private void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Vector3 lookPoint = new Vector3(player.position.x + interactionDistance, player.position.y + interactionDistance);
        Ray ray = new Ray(lookPoint, Vector3.one / 2f);
        RaycastHit hit;
        bool hitSmth = false;

        if(Physics.Raycast(ray,out hit, interactionDistance))
        {
            IInteractable interactable=hit.collider.GetComponent<IInteractable>();

            if(interactable!=null) { 
                hitSmth= true;
                interactionText.text = interactable.GetDescription();

                if(Input.GetKeyDown(KeyCode.E)) {
                    interactable.Interact();
                }
            }
        }
        interactionUI.SetActive(hitSmth);
    }
}
