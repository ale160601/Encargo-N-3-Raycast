using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListaDeCompras : MonoBehaviour
{
    public GameObject panelListaDeCompras; // Referencia al panel
    public TextMeshProUGUI textoLista;     // Texto donde se mostrarán los productos
    public List<string> productosAComprar; // Lista de productos a comprar

    private bool panelActivo = false;

    void Start()
    {
        panelListaDeCompras.SetActive(false); // Asegúrate de que el panel esté oculto al inicio
        ActualizarListaDeCompras();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            panelActivo = !panelActivo;
            panelListaDeCompras.SetActive(panelActivo);
        }
    }

    void ActualizarListaDeCompras()
    {
        textoLista.text = "Productos por comprar:\n";

        foreach (string producto in productosAComprar)
        {
            textoLista.text += $"- {producto}\n";
        }
    }
}
