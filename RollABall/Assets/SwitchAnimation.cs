using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody parentRb;
    
    public float movementThreshold = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        parentRb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Esta entrando na animacao");

        // Exemplo de altera��o da vari�vel "Speed" na anima��o
        bool isWalking = parentRb.velocity.magnitude > movementThreshold;
        // Define o valor da vari�vel "Speed" na anima��o   
        animator.SetBool("walk", isWalking);

    }
}
