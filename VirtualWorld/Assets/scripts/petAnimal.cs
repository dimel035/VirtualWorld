using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petAnimal : MonoBehaviour
{
    [SerializeField]Animator anim;
    [SerializeField] npcRandomPatrol rp;


    public void Interact(bool pet)
    {
        if (pet)
        {
            //rp.stopPatrol=true;
            Debug.Log("pet");
        }
        else
        {
            //rp.stopPatrol = false;
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
