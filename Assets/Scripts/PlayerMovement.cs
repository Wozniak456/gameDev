using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;
    public Joystick Joystick; 
    private float _horizontalMove = 0f;
    private float runSpeed = 40f;

    private bool jump = false;
    private bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        // _horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        _horizontalMove = Joystick.Horizontal * runSpeed;

        float verticalMove = Joystick.Vertical;

        animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));
        
        // if (Input.GetButtonDown("Jump")) 
        if (verticalMove >= .5f)
        {
            animator.SetBool("IsJumping", true);
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
            crouch = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        jump = false;
    }

    void FixedUpdate()
    {
        controller.Move(_horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
