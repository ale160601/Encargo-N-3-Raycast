using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producto : MonoBehaviour
{
    public ProductoData datos;

    public string GetInfo()
    {
        return $"{datos.nombre}: ${datos.precio:F2}";
    }
}
