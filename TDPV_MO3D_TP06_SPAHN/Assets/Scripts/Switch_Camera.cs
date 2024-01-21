using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch_Camera : MonoBehaviour
{
    [SerializeField] Camera mainCamera, secondaryCamera;//camaras que utilizaremos

    public void Switch_Cameras()
    {//funcion con la que cambiaremos de camara entre la principal y la secundaria
        if (Input.GetKeyDown(KeyCode.S)&&mainCamera.enabled)
        {
            mainCamera.enabled = false;
            secondaryCamera.enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.L)&&secondaryCamera.enabled)
        {
            mainCamera.enabled = true;
            secondaryCamera.enabled = false;
        }
    }

    void Update()
    {//actualizamos la funcion que cambia las camaras
        Switch_Cameras();
    }
}
