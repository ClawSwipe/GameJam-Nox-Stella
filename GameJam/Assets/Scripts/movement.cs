using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public AudioSource src;
    public AudioClip sfx;
    Animator animator;
    public CharacterController controller;
    public Joystick joystick;
    public float runSpeed = 100f;

    public float moveDashSpeed = 1000f;
    public float idleDashSpeed = 1500f;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;

    public Vector3 direction;
    public Vector3 lastDirection;

    private string forward_BOOL = "forward";
    private string idle_Bool = "idle";


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;
        direction = new Vector3(horizontalMove, 0f, verticalMove).normalized;
        Move(direction, runSpeed);
    }


    void Move(Vector3 direction, float speed)
    {
        //m.SetFloat("horizontalSpeed", horizontalMove);
        if (direction.magnitude >= 0.1f)
        {
            lastDirection = direction;
            float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetangle, 0f);
            Animate(forward_BOOL);
            controller.Move(direction * speed * Time.deltaTime);

        }
        else
        {
            Animate(idle_Bool);

        }
    }



    private void Animate(string animation)
    {
        DisableAnimations(animator, animation);
        animator.SetBool(animation, true);
    }

    private void DisableAnimations(Animator animator, string animation)
    {
        foreach (var parameter in animator.parameters)
        {
            if (animation != parameter.name)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }


    public void Dash()
    {
        src.clip = sfx;
        src.Play();
        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;
        direction = new Vector3(horizontalMove, 0f, verticalMove).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Move(direction, moveDashSpeed);

        }
        else
        {
            Move(lastDirection, idleDashSpeed);

        }

    }


}
