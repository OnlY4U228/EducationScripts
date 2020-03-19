using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandlerFirst : MonoBehaviour
{
    #region var
        public int Score;
        public float MoveSpeed = 5f;
        public float JumpPower = 100f;
        private float gravityForce = 0;
        private Vector3 moveVector; 
        private CharacterController ch_controller;

        public bool TestBool;
    #endregion
    private void Start()
    {
        Cursor.visible = false;
        ch_controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        moveVector = Vector3.zero;
        Gravity();
    }
    private void FixedUpdate()
    {
        ch_controller.Move(moveVector * MoveSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * MoveSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.D))
            transform.Translate(-Vector3.left * MoveSpeed * Time.deltaTime);
    }
    private void Gravity()
    {
        if(!ch_controller.isGrounded)
        {
            gravityForce -= 20f * Time.deltaTime;
        }          
        else gravityForce = -1f;
        if(Input.GetKey(KeyCode.Space) && ch_controller.isGrounded) 
        {
            gravityForce = JumpPower;  
        }           
        moveVector.y = gravityForce; 
    }
}
