
using UnityEditor;
using UnityEngine;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{

    public virtual void Interact()
    {
        Debug.Log($"{gameObject.name} was interacted with.");
    }

    public virtual void Highlight()
    {

        Debug.Log($"{gameObject.name} is highlighted.");
    }

    public virtual void Unhighlight()
    {
        Debug.Log($"{gameObject.name} is no longer highlighted.");

    }

}
