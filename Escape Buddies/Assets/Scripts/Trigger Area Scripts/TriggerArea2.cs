using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea2 : MonoBehaviour
{
    public Animator anim;
    public GameObject door;
    public bool isRising = false;

     void Start()
    {
        anim = door.GetComponent<Animator>();
    }
      void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player" && isRising == false)
            {
                anim.SetBool("isRising", true);
            isRising = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && isRising == true)
        {
            anim.SetBool("isRising", false);
            isRising = false;
        }
    }
}
