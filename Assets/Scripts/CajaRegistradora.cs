using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CajaRegistradora : MonoBehaviour
{
    public Button botonConfirmar;
    public Inventory inventario;
    public UIController uiController;

    void Start()
    {
        botonConfirmar.gameObject.SetActive(false);
        botonConfirmar.onClick.AddListener(ConfirmarCompra);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MostrarBotonConfirmar();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OcultarBotonConfirmar();
        }
    }

    public void ConfirmarCompra()
    {
        Debug.Log("Compra confirmada");

        List<ProductoData> productos = inventario.items;//obtiene los productos del inventario
        uiController.ConfirmarCompra(productos);//llama a la UI para mostrar la compra
        inventario.LimpiarInventario();//limpia el inventario despues de la compra

        OcultarBotonConfirmar();
    }

    private void MostrarBotonConfirmar()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        botonConfirmar.gameObject.SetActive(true);
    }

    private void OcultarBotonConfirmar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        botonConfirmar.gameObject.SetActive(false);
    }
}
