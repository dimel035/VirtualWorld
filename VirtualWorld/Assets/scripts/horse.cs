
using UnityEngine;


public class horse : InteractableBase
{

    public override void Interact()
    {
        base.Interact();
        Debug.Log("The horse is being petted.");
    }

    public override void Highlight()
    {
        base.Highlight();

    }

    public override void Unhighlight()
    {
        base.Unhighlight();

    }
}
