using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;

    public virtual void Interact()
    {
        Debug.Log("interacting with" + transform.name);
    }

    private void Update()
    {
        if(isFocus && !hasInteracted )
        {
            float distance = Vector3.Distance(interactionTransform.position, player.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted= true;
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocus = false;
        hasInteracted = false;
        player = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
