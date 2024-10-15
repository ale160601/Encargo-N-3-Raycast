using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoController : MonoBehaviour
{
    public Transform player;
    public float followDistance = 2f;    //distancia máxima para agarrar el carrito
    public float moveSpeed = 5f;         //velocidad de movimiento del carrito
    private Rigidbody carritoRb;
    private bool isCarryingCart = false; //para saber si el carrito esta siendo controlado

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

        //controlar el carrito si esta siendo llevado
        if (isCarryingCart)
        {
            ControlarCarrito();
        }
    }

    private bool PuedeAgarrarCarrito()
    {
        //verifica si el carrito esta a una corta distancia del jugador
        float distancia = Vector3.Distance(transform.position, player.position);
        Debug.Log("Distancia al carrito: " + distancia);
        return distancia <= followDistance;
    }

    private void AgarrarCarrito()
    {
        isCarryingCart = true;
        carritoRb.isKinematic = true;  //desactiva la física para controlar el carrito
        carritoRb.transform.SetParent(player); //hace al carrito hijo del jugador
        Debug.Log("Carrito agarrado.");
    }

    private void SoltarCarrito()
    {
        isCarryingCart = false;
        carritoRb.isKinematic = false;  //reactiva la fisica del carrito
        carritoRb.transform.SetParent(null);
        Debug.Log("Carrito soltado.");
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
}