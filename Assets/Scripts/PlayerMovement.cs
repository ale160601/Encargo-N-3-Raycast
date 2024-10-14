using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de movimiento
    public float turnSpeed = 200f;    // Velocidad de rotaci�n
    public float jumpForce = 5f;      // Fuerza del salto
    public bool isGrounded;           // Verifica si el personaje est� en el suelo
    public LayerMask groundMask;      // Capa que define qu� es el suelo
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento hacia adelante/atr�s
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * move);

        // Rotaci�n izquierda/derecha
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
        // Detecta si el personaje est� en contacto con el suelo
        if ((groundMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Detecta si el personaje ya no est� en contacto con el suelo
        if ((groundMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = false;
        }
    }
}
