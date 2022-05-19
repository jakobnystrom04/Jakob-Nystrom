using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Skript för all movement
    
    public CharacterController controller;

    public float speed = 12f;
    readonly float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float bastianHeight;
    float normalHeight;
    float dash = 0;
    float dashCooldown = -5;
    float dashDurationA = -10;

    Vector3 velocity;

    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    CharacterController playerCtrl;

    

    bool isGrounded;

    
    public float CoolDown = 3;

    // Update is called once per frame

    private void Start()
    {
        playerCtrl = GetComponent<CharacterController>();
        normalHeight = playerCtrl.height;
        //Den hämtar din längd och din charactercontroller som används för movement

    }
    void Update()
    {

        

        if (Time.time - dashCooldown >= 5)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
            dashCooldown = Time.time;
            dash = 0;
            dashDurationA = Time.time;  
            //Aktiverar sprint ifall cooldownen har gått ner (jag vet att det står dash men det är sprint)
            }
        }

        if (Time.time - dashDurationA <= 3)
        {
            speed = 20f;
            //aktiverar högre speed om sprint är aktivetat
        }
        else
        {
            speed = 12f;
            //sätter tillbaka speed när sprint blir avaktiverat
        }
        //Detta skriptet, kollar ifall du står på marken, sedan sätter den så att man inte accelererar neråt, den skaffar z-axel och x-axel, så att man sedan kan flytta längs de axlarna, den sätter sedan in en jump-funktion för att kunna hoppa och sedan falla.

        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            //Ifall du står på marken och inte rör dig uppåt så får du en hastighet neråt.
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //hämtar bara olika axlar

        Vector3 move = transform.right * x + transform.forward * z;
        //Aktiverar rörelse beroende på vad x och z bestäms till

        controller.Move(move * speed * Time.deltaTime);
        //Flyttar dig

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            //Fysiken för hoppet
        }

        velocity.y += gravity * Time.deltaTime;
        

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //speed = 160000000f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //speed = 12f;
        }

        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed = 4f;
            Bastian();
            //Crouch när left control trycks ner
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = 12f;
            UnBastian();
            //Uncrouch när left control släpps
        }


        
    }
    void Bastian()
    {
        playerCtrl.height = bastianHeight;
        //Crouch
    }

    void UnBastian()
    {
        playerCtrl.height = normalHeight;
        //Uncrouch
    }



}
