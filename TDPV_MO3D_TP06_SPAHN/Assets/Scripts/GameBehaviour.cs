using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] Bar Bar, Bar1;//barras para mostrar como carga la fuerza que tendra la bola;
    [SerializeField] private Transform LB;//limite a la izquierda
    [SerializeField] private Transform RB;//limite a la derecha
    Rigidbody rb;//rigid body
    bool sprite = true;//booleano que me ayuda para actualizar al inicio la barra
    private bool Restrict_Movement = false;//booleano que me permite hacer que no podamos mover la bola luego de lanzarla
    bool Ready_To_Charge;//booleano que me dice si se puede empezar a cargar la fuerza con la que se lanzara la bola
    bool Charging;//booleano que me dice que esta cargando la fuerza
    private float Actual_Force;//flotante que me indica la fuerza actual que tiene la bola
    private readonly float Max_Force=1;//flotante que controla la fuerza maxima que puede alcanzar la bola
    private readonly float Altura = -10f;//flotante que me permite saber si la bola ya paso la altura necesaria hacia abajo para reiniciar la escena

    void Start()
    {//inicializamos variables
        rb = GetComponent<Rigidbody>();
        Ready_To_Charge = true;
    }

    void Ball_Movement_Behaviour()
    {//funcion para mover la bola
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector3 movimiento = transform.position + new Vector3(0.1f * movimientoHorizontal, 0f, 0f);
        movimiento.x = Mathf.Clamp(movimiento.x, LB.position.x, RB.position.x);
        transform.position = movimiento;
    }

    void Inputs()
    {//funcion que controla si se preciona o suelta la barra espaciadora para cargar o tirar respectivamente
        if (Input.GetKeyDown(KeyCode.Space) && Ready_To_Charge)
        {
            Charging = true;
            sprite = false;
            Restrict_Movement = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
            Ready_To_Charge = false;
        }
    }

    void Charging_up()
    {//funcion con la que cargamos la fuerza
        Actual_Force += Time.fixedDeltaTime;
        Actual_Force = Mathf.Clamp(Actual_Force, 0, Max_Force);
    }

    void Shoot()
    {//funcion con la que lanzamos la bola
        Charging = false;
        rb.AddForce(10* Actual_Force * Vector3.forward, ForceMode.Impulse);
        Actual_Force = 0f;
    }

    void Restart()
    {//funcion para reiniciar la escena
        if (Input.GetKeyDown(KeyCode.R) || transform.position.y < Altura)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {//actualizamos algunas funciones
        if (!Restrict_Movement)
        {
            Ball_Movement_Behaviour();
        }  
        if (Charging)
        {
            Charging_up();
            Bar.Update_Inner_Bar(Actual_Force);
            Bar1.Update_Inner_Bar(Actual_Force);
        }
    }

    void Update()
    {//actualizamos algunas funciones
        Inputs();
        if (sprite)
        {
            Bar.Update_Inner_Bar(Actual_Force);
            Bar1.Update_Inner_Bar(Actual_Force);
        }
        Restart();
    }
}
