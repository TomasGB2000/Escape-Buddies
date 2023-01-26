using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public Animator anim;
    public bool isOpen = false;
    public GameObject Door;

     void Start()
    {
        anim = Door.GetComponent<Animator>();
    }
      void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player" && isOpen == false)
            {
                anim.SetBool("isOpen", true);
                isOpen = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && isOpen == true)
        {
            anim.SetBool("isOpen", false);
            isOpen = false;
        }
    }
}
