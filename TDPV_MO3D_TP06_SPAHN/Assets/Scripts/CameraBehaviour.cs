using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Ball;//declaramos el objeto que luego usaremos
    float Distance;//flotante que controla la distancia entre la camara y la bola

    void Start()
    {//asignamos la distancia que tendra la camara respecto a la bola
        Distance = transform.position.z - Ball.transform.position.z;
    }


    void Update()
    {//actualizamos la funcion de abajo
        Update_Camera_Position();
    }
    void Update_Camera_Position()
    {//funcion que permite actualizar la posicion de la camara
        transform.position = new Vector3(transform.position.x, transform.position.y, Ball.transform.position.z + Distance);
    }
}
