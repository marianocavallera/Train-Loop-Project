using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ControladorEnemigo : MonoBehaviour
{

    private float minX, maxX, minY, maxY;
    public float tiempoenemigos;
    public float maxenemigos;
    private float tiempoalsig;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] Enemigos;


    private void Start(){
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    private void Update(){
        tiempoalsig += Time.deltaTime;

        if(tiempoalsig >= tiempoenemigos){
            tiempoalsig = 0;
            //crea el enemigo
            CrearEnemigo();
        }
    }

    private void CrearEnemigo(){
        int numeroEnemigo = Random.Range(0, Enemigos.Length);
        Vector2 posicionaleat = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(Enemigos[numeroEnemigo], posicionaleat, Quaternion.identity);
    }
}