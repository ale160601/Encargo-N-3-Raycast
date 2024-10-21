using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public List<ProductoData> items = new List<ProductoData>();
    public float dineroInicial = 100f;
    public TextMeshProUGUI dineroUI;

    void Start()
    {
        ActualizarDineroUI();
    }

    public void AddToInventory(ProductoData producto)
    {
        if (!ContieneProducto(producto))
        {
            items.Add(producto);
            Debug.Log($"{producto.nombre} añadido al inventario.");
        }
        else
        {
            Debug.Log($"{producto.nombre} ya está en el inventario.");
        }
    }

    public void RemoveFromInventory(ProductoData producto)
    {
        if (ContieneProducto(producto))
        {
            items.Remove(producto);
            Debug.Log($"{producto.nombre} eliminado del inventario.");
        }
    }

    private bool ContieneProducto(ProductoData producto)
    {
        return items.Contains(producto);
    }

    public float CalcularTotal()
    {
        float total = 0f;
        foreach (ProductoData producto in items)
        {
            total += producto.precio;
        }
        return total;
    }

    public bool Comprar()
    {
        float total = CalcularTotal();
        if (dineroInicial >= total)
        {
            dineroInicial -= total;
            ActualizarDineroUI();
            Debug.Log("Compra realizada exitosamente.");
            return true;
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para la compra.");
            return false;
        }
    }
    private void ActualizarDineroUI()
    {
        if (dineroUI != null)
        {
            dineroUI.text = $"${dineroInicial:F2}";
        }
        else
        {
            Debug.LogWarning("Referencia a dineroUI no asignada.");
        }
    }
}
