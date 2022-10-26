using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{

    public float speed = 3f;
    private Rigidbody2D playeRb;
    private Animator Animator;
    private Vector2 moveInput;
    public GameObject BalaPrefab;
    private float ultimabala;

    void Start()
    {
        playeRb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //movimiento para la izquierda
        if(moveX < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (moveX > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        moveInput = new Vector2(moveX, moveY).normalized;
        Animator.SetBool("AimUp", moveY > 0.0f);
        Animator.SetBool("AimDown", moveY < 0.0f);
        
        Animator.SetBool("Running", moveY != 0.0f);
        Animator.SetBool("Running", moveX != 0.0f);

        if(Input.GetMouseButtonDown(0) && Time.time > ultimabala + 0.25f){
            Disparo();
            ultimabala = Time.time;
        }
        
    }

    private void FixedUpdate()
    {
        playeRb.MovePosition(playeRb.position + moveInput * speed * Time.fixedDeltaTime);
    }
    
    private void Disparo(){

        Vector3 direction;
            if(transform.localScale.x == 1.0f) direction = Vector2.right;
            else direction = Vector2.left;
        GameObject bala = Instantiate(BalaPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bala.GetComponent<BalaScript>().SetDirection(direction);
    }
}
