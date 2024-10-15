using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de movimiento
    public float turnSpeed = 200f;    // Velocidad de rotaci�n del cuerpo
    public float jumpForce = 5f;      // Fuerza del salto
    public bool isGrounded;           // Verifica si el personaje est� en el suelo
    public LayerMask groundMask;      // Capa que define qu� es el suelo

    public Transform playerCamera;    // C�mara del jugador
    public float mouseSensitivity = 2f;  // Sensibilidad del mouse
    public float maxLookAngle = 80f;  // �ngulo m�ximo para mirar hacia arriba/abajo

    private Rigidbody rb;
    private float verticalRotation = 0f; // Controla la rotaci�n vertical de la c�mara

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Esconde y bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MoverJugador();
        RotarJugador();
        Saltar();
    }

    private void MoverJugador()
    {
        // Movimiento hacia adelante/atr�s y lateral
        float moveForward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveSide = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        Vector3 movimiento = transform.forward * moveForward + transform.right * moveSide;
        transform.position += movimiento;
    }

    private void RotarJugador()
    {
        // Rotaci�n horizontal del jugador (izquierda/derecha)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, mouseX, 0);

        // Rotaci�n vertical de la c�mara (arriba/abajo)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation -= mouseY;  // Invertimos el movimiento del mouse en Y
        verticalRotation = Mathf.Clamp(verticalRotation, -maxLookAngle, maxLookAngle);  // Limitar �ngulo

        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void Saltar()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detecta si el personaje est� en contacto con el suelo
        if ((groundMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Detecta si el personaje ya no est� en contacto con el suelo
        if ((groundMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = false;
        }
    }
}
