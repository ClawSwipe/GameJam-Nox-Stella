using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{   

    Animator m;

    public Joystick joystick;
     public float runSpeed = 5f;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;



    // Start is called before the first frame update
    void Start()
    {
        m =gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal * runSpeed;
        verticalMove = joystick.Vertical * runSpeed;
        m.SetFloat("horizontalSpeed", horizontalMove);
    }
}
