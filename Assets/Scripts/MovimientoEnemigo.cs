using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    private Rigidbody2D rb;
    private float distancia;
    public float speedenemigo;
    public GameObject Jugador;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(transform.position, Jugador.transform.position);
        Vector2 direction = Jugador.transform.position - transform.position;
        direction.Normalize();

        float angulo = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distancia < 2){
            transform.position = Vector2.MoveTowards(this.transform.position, Jugador.transform.position, speedenemigo * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angulo);
        }
    }
}
