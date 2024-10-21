using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoController : MonoBehaviour
{
    public Transform carritoContenido;  // Empty Object dentro del carrito
    public Inventory inventario;        // Referencia al inventario
    public Transform player;
    public float followDistance = 2f;
    public float moveSpeed = 5f;
    private Rigidbody carritoRb;
    private bool isCarryingCart = false;

    void Start()
    {
        carritoRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isCarryingCart)
            {
                SoltarCarrito();
            }
            else if (PuedeAgarrarCarrito())
            {
                AgarrarCarrito();
            }
        }

        if (isCarryingCart)
        {
            ControlarCarrito();
        }
    }

    private bool PuedeAgarrarCarrito()
    {
        float distancia = Vector3.Distance(transform.position, player.position);
        return distancia <= followDistance;
    }

    private void AgarrarCarrito()
    {
        isCarryingCart = true;
        carritoRb.isKinematic = true;
        carritoRb.transform.SetParent(player);
    }

    private void SoltarCarrito()
    {
        isCarryingCart = false;
        carritoRb.isKinematic = false;
        carritoRb.transform.SetParent(null);
    }

    private void ControlarCarrito()
    {
        Vector3 direccion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 movimiento = player.forward * direccion.z + player.right * direccion.x;

        if (direccion.magnitude > 0)
        {
            carritoRb.AddForce(movimiento.normalized * moveSpeed, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Producto producto = other.GetComponent<Producto>();
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (producto != null && rb != null)
            {
                inventario.AddToInventory(producto.datos);
                other.transform.SetParent(carritoContenido);
                Debug.Log($"{producto.datos.nombre} añadido al carrito.");
            }
            else
            {
                Debug.LogWarning($"El objeto {other.name} no tiene un Rigidbody o no es un producto válido.");
            }
        }
    }
}