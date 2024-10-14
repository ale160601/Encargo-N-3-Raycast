using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    public void AddToInventory(GameObject item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            Debug.Log(item.name + " añadido al inventario.");
        }
    }

    public void RemoveFromInventory(GameObject item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.name + " eliminado del inventario.");
        }
    }
}
