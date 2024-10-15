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
        dineroText.text = $"Dinero: ${dinero}";
    }

    public void ConfirmarCompra(List<ProductoData> productosComprados)
    {
        float total = 0f;
        string listaProductos = "";

        foreach (var producto in productosComprados)
        {
            total += producto.precio;
            listaProductos += $"{producto.nombre} - ${producto.precio}\n";
        }

        if (total > dinero)
        {
            Debug.Log("Dinero insuficiente");
        }
        else
        {
            dinero -= Mathf.RoundToInt(total);
            ActualizarDinero();

            int vuelto = dinero;

            MostrarBoleta(listaProductos, Mathf.RoundToInt(total), vuelto);
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