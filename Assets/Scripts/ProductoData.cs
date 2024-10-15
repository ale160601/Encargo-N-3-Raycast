using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoProducto", menuName = "Supermercado/Producto")]
public class ProductoData : ScriptableObject
{
    public string nombre;
    public float precio;
    public Sprite icono;
}
