using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea4 : MonoBehaviour
{
    public Animator anim;
    public bool isRising = false;
    public GameObject Door;

    void Start()
    {
        anim = Door.GetComponent<Animator>();
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
