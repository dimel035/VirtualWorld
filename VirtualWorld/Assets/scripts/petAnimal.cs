using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petAnimal : MonoBehaviour
{
    [SerializeField]Animator anim;


    public void Interact(bool pet)
    {
        if (pet)
        {
            Debug.Log("pet");
        }
        else
        {
            Debug.Log("stop petting");
        }
        
/*        if(pet)
        {
            anim.SetBool("pet", true);
        }
        else
        {
            anim.SetBool("pet", false);
        }*/
    }
}
