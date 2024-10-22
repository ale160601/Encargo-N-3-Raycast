using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CajaRegistradora : MonoBehaviour
{
    public Button botonConfirmar;
    public Inventory inventario;  // Referencia al inventario
    public UIController uiController;  // Referencia al UIController

    void Start()
    {
        botonConfirmar.gameObject.SetActive(false);
        botonConfirmar.onClick.AddListener(ConfirmarCompra);  // Agrega el listener del botón
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

        List<ProductoData> productos = inventario.items;  // Obtiene los productos del inventario
        uiController.ConfirmarCompra(productos);  // Llama a la UI para mostrar la compra
        inventario.LimpiarInventario();  // Limpia el inventario después de la compra

        OcultarBotonConfirmar();  // Oculta el botón después de confirmar la compra
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
