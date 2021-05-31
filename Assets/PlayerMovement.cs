using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        //animator.SetFloat("AirSpeedY", verticalMove);
        //Debug.Log(verticalMove);

        if (Mathf.Abs(horizontalMove)>0)
        {
            animator.SetInteger("AnimState", 1);
        } else
        {
            animator.SetInteger("AnimState", 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack1");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("Attack2");
        }

        if (Input.GetButtonDown("Fire3"))
        {
            animator.SetTrigger("Attack3");
        }

        if (Input.GetButtonDown("Block"))
        {
            animator.SetTrigger("Block");
        }

    }

    public void OnLanding ()
    {
        animator.SetBool("Jump", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
