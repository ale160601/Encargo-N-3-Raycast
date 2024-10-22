using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text dineroText;
    public GameObject boletaPanel;
    public TMP_Text boletaText;
    public int dineroInicial = 100;
    private int dinero;

    void Start()
    {
        dinero = dineroInicial;
        ActualizarDinero();
        boletaPanel.SetActive(false);
    }

    public void ActualizarDinero()
    {
        dineroText.text = $"${dinero}";
    }

    public void ConfirmarCompra(List<ProductoData> productosComprados)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (productosComprados.Count == 0)
        {
            Debug.Log("No hay productos en el carrito.");
            return;
        }

        float total = 0f;
        string listaProductos = "";

        foreach (var producto in productosComprados)
        {
            total += producto.precio;
            listaProductos += $"{producto.nombre} - ${producto.precio:F2}\n";
        }

        if (total > dinero)
        {
            Debug.Log("Dinero insuficiente para completar la compra.");
        }
        else
        {
            dinero -= Mathf.RoundToInt(total);
            ActualizarDinero();
            MostrarBoleta(listaProductos, Mathf.RoundToInt(total), dinero);
        }
    }

    public void MostrarBoleta(string productos, int total, int vuelto)
    {
        boletaText.text =
            $"Productos Comprados:\n{productos}\n" +
            $"Total: ${total}\n" +
            $"Dinero Restante: ${vuelto}";
        boletaPanel.SetActive(true);

    }

    public void CerrarBoleta()
    {
        boletaPanel.SetActive(false);
    }
}