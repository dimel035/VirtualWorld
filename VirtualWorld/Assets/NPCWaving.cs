using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWaving : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            wave();
        }
    }

    void wave()
    {
        anim.SetTrigger("waving");
    }
}
