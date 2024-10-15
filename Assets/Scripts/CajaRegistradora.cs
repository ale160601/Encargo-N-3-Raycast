using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CajaRegistradora : MonoBehaviour
{
    public Button botonConfirmar;

    void Start()
    {
        botonConfirmar.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
 
        if (other.CompareTag("Player"))
        {
            //muestra el botón cuando el jugador entra en el area
            botonConfirmar.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            botonConfirmar.gameObject.SetActive(false);
        }
    }
}
