using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoController : MonoBehaviour
{
    public Transform player;             // Referencia al jugador
    public float followDistance = 2f;    // Distancia máxima para agarrar el carrito
    public float moveSpeed = 5f;         // Velocidad de movimiento del carrito

    private Rigidbody carritoRb;         // Referencia al Rigidbody del carrito
    private bool isCarryingCart = false; // Estado para saber si el carrito está siendo controlado

    void Start()
    {
        carritoRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Agarrar o soltar el carrito
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

        // Controlar el carrito si está siendo llevado
        if (isCarryingCart)
        {
            ControlarCarrito();
        }
    }

    private bool PuedeAgarrarCarrito()
    {
        // Verifica si el carrito está a una distancia razonable del jugador
        float distancia = Vector3.Distance(transform.position, player.position);
        Debug.Log("Distancia al carrito: " + distancia); // Debug de distancia
        return distancia <= followDistance;
    }

    private void AgarrarCarrito()
    {
        isCarryingCart = true;
        carritoRb.isKinematic = true;  // Desactiva la física para controlar el carrito
        carritoRb.transform.SetParent(player); // Establece al carrito como hijo del jugador
        Debug.Log("Carrito agarrado.");
    }

    private void SoltarCarrito()
    {
        isCarryingCart = false;
        carritoRb.isKinematic = false;  // Reactiva la física del carrito
        carritoRb.transform.SetParent(null); // Desvincula el carrito del jugador
        Debug.Log("Carrito soltado.");
    }

    private void ControlarCarrito()
    {
        // Crear un vector de movimiento
        Vector3 direccion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 movimiento = player.forward * direccion.z + player.right * direccion.x;

        // Aplica fuerza al carrito si la dirección no es cero
        if (direccion.magnitude > 0)
        {
            carritoRb.AddForce(movimiento.normalized * moveSpeed, ForceMode.Acceleration);
        }
    }
}