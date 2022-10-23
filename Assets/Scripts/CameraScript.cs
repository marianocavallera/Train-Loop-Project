using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Player.transform.position.x;
        position.y = Player.transform.position.y;
        transform.position = position;
    }
}
