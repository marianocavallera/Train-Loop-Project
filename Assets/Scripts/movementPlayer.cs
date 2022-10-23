using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{

    private float speed = 3f;
    private Rigidbody2D playeRb;
    private Animator Animator;
    private Vector2 moveInput;
    
    // Start is called before the first frame update
    void Start()
    {
        playeRb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
        
        Animator.SetBool("Running", moveX != 0.0f);
        Animator.SetBool("Running", moveY != 0.0f);
        
    }

    private void FixedUpdate()
    {
        playeRb.MovePosition(playeRb.position + moveInput * speed * Time.fixedDeltaTime);
    }
    
}
