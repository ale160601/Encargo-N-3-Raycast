using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ProductoData> items = new List<ProductoData>();
    public float dineroInicial = 100f;
    public Text dineroUI;

    void Start()
    {
        ActualizarDineroUI();
    }

    public void AddToInventory(ProductoData producto)
    {
        if (!items.Contains(producto))
        {
            items.Add(producto);
            Debug.Log($"{producto.nombre} añadido al inventario.");
        }
    }

    public void RemoveFromInventory(ProductoData producto)
    {
        if (items.Contains(producto))
        {
            items.Remove(producto);
            Debug.Log($"{producto.nombre} eliminado del inventario.");
        }
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
            return true;
        }
        else
        {
            Debug.Log("No tienes suficiente dinero.");
            return false;
        }
    }

    private void ActualizarDineroUI()
    {
        dineroUI.text = $"Dinero: ${dineroInicial:F2}";
    }
}
