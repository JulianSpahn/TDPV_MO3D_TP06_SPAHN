using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    private GameObject innerBar;//declaramos el objeto que vamos utilizar

    void Start()
    {//seteamos el objeto
        innerBar = gameObject.transform.GetChild(1).gameObject;
    }

    public void Update_Inner_Bar(float size)
    {//funcion que se encarga de actualizar la barra de carga de fuerza de la bola
        Vector3 newSize = new Vector3(size, innerBar.transform.localScale.y, innerBar.transform.localScale.z);
        innerBar.transform.localScale = newSize;
    }
}
