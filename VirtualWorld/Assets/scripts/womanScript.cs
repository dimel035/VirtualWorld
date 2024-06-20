using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class womanScript : MonoBehaviour
{

    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isHot();
        }
    }

    void isHot()
    {
        anim.SetTrigger("isHot");
    }
}
