using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakeScript : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    public float speed;

    private Vector3 rot;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }

    void Move(){
        if(controller.isGrounded){
            if(Input.GetKey(KeyCode.W | KeyCode.UpArrow)){
                animator.SetBool("walk", true);

                moveDirection = Vector3.forward * speed;

            }

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if(moveDirection.magnitude > 0.1f){
                animator.SetBool("walk", true);
            }else{
                animator.SetBool("walk", false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
