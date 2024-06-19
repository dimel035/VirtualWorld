using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petAnimal : MonoBehaviour, IInteractable
{
    [SerializeField]Animator anim;
    bool pet=false;

    public string GetDescription()
    {
        return "Pet";
    }

    public void Interact()
    {
        if (pet)
        {
            anim.SetBool("pet", false);
        }
        else
        {
            anim.SetBool("pet", true);
        }
    }
}
