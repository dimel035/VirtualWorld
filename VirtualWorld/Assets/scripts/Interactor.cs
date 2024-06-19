using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Interactor : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject interactionUI;
    public Interactable focus;
    public TextMeshProUGUI interactionText;
    bool interacting = false;
    petAnimal p;

    Transform target;
    NavMeshAgent agent;
    ThirdPersonController tpc;

    private void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        tpc= GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*        if(target!=null)
                {
                    agent.SetDestination(target.position);
                    FaceTarget();
                }*/
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hitSmth = false;

        if (Physics.Raycast(ray,out hit, 100))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null) 
            {
                hitSmth = true;
                interactionText.text = "Pet";
                interactionUI.SetActive(hitSmth);
                if (Input.GetButtonDown("e"))
                {
                    if (!interacting)
                    {
                        SetFocus(interactable);
                    }
                    else
                    {
                        Defocus();
                    }
                }

            }
            else
            {
                hitSmth = false;
                interactionText.text = "Interact";
                interactionUI.SetActive(hitSmth);
            }
            
        }
    
/*        if (Input.GetButtonDown("t"))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Defocus();
            }
        }*/
    }

    void SetFocus(Interactable focusObject)
    {
        if(focusObject != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            focus = focusObject;
            p = new petAnimal();
            p.Interact(true);
            interacting= true;
            //follow
        }

        focusObject.OnFocused(transform);

    }

    void Defocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        p.Interact(false);
        p=null;
        interacting = false;
    }

/*    public void FollowTarget(Interactable currentTarget) 
    {
        agent.stoppingDistance = currentTarget.radius * .8f;
        agent.updateRotation = false;

        target = currentTarget.interactionTransform;
        tpc.Move();
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }*/
}
