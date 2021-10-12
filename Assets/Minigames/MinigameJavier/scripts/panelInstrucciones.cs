using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelInstrucciones : MonoBehaviour
{
    public GameObject Instrucciones;

    public void abrirPanel()
    {
        if (Instrucciones != null)
        {
            Instrucciones.SetActive(true);
        }
    }

    public void cerrarPanel()
    {
        if (Instrucciones != null)
        {
            Instrucciones.SetActive(false);
        }
    }




}
