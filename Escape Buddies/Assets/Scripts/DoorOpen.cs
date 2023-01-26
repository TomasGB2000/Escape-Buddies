using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator anim;
    public bool isOpen;

    private void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
    }

    private void OnDoorwayOpen()
    {
        isOpen = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        anim = GetComponent<Animator>();
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (collision.gameObject.tag == "Player" && isOpen == false)
        {
            anim.SetBool("Open", true);
            anim.Play("Open");

            isOpen = true;
        }
    }
}
