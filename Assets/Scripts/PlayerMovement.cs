using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de movimiento
    public float turnSpeed = 200f;    // Velocidad de rotación
    public float jumpForce = 5f;      // Fuerza del salto
    public bool isGrounded;           // Verifica si el personaje está en el suelo
    public LayerMask groundMask;      // Capa que define qué es el suelo
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento hacia adelante/atrás
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * move);

        // Rotación izquierda/derecha
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Detecta si el personaje está en contacto con el suelo
        if ((groundMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Detecta si el personaje ya no está en contacto con el suelo
        if ((groundMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = false;
        }
    }
}
