using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{

    public float speed = 3f;
    private Rigidbody2D playeRb;
    private Animator Animator;
    private Vector2 moveInput;
    public float moveSpeed;
    //bala y tiempo de bala
    public GameObject BalaPrefab;
    private float ultimabala;
    //-- bala y tiempo de bala 

    //deslizar
    private float activeMoveSpeed;
    public float deslizarspeed;
    public float deslizardistancia = 2.5f, deslizarcooldown = 1f;
    private float deslizarcontador;
    private float deslizarcant;
    //--deslizar
    void Start()
    {
        playeRb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        activeMoveSpeed = speed;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //movimiento para la izquierda
        if(moveX < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (moveX > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        moveInput = new Vector2(moveX, moveY).normalized;
        //Anim
        Animator.SetBool("AimUp", moveY > 0.0f);
        Animator.SetBool("AimDown", moveY < 0.0f);
        
        //Animator.SetBool("Running", moveY != 0.0f);
        Animator.SetBool("Running", moveX != 0.0f);
        //-- Anim

        //Disparo input
        if(Input.GetMouseButtonDown(0) && Time.time > ultimabala + 0.25f){
            Disparo();
            ultimabala = Time.time;
        }
        //-- Disparo input

        //deslizar input
        if(Input.GetKeyDown(KeyCode.Space)){
            if(deslizarcant <=0 && deslizarcontador <=0){
                activeMoveSpeed = deslizarspeed;
                deslizarcontador = deslizardistancia;
            }
        }
        if(deslizarcontador > 0){
            deslizarcontador -= Time.deltaTime;

            if(deslizarcontador <=0){
                activeMoveSpeed = speed;
                deslizarcant = deslizarcooldown;
            }
        }
        if(deslizarcant > 0){
            deslizarcant -= Time.deltaTime;
        }
        //-- deslizar input
    }

    private void FixedUpdate()
    {
        playeRb.MovePosition(playeRb.position + moveInput * speed * Time.fixedDeltaTime);
        //playeRb.velocity = moveInput * activeMoveSpeed * speed; 
    }
    
    private void Disparo(){

        Vector3 direction;
            if(transform.localScale.x == 1.0f) direction = Vector2.right;
            else direction = Vector2.left;
        GameObject bala = Instantiate(BalaPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bala.GetComponent<BalaScript>().SetDirection(direction);
    }
}
