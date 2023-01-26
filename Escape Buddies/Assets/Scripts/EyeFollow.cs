using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public Transform followObject;

    public Transform rightObject;
    public Transform leftObject;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(followObject);

        if (Input.GetKey(KeyCode.A))
        {
            transform.LookAt(leftObject);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.LookAt(rightObject);
        }
    }
}
