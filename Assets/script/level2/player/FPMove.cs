using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPMove : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    private Rigidbody rb;
    public TextMeshProUGUI warningText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Obtener la entrada de movimiento (Horizontal y Vertical)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Convertir el movimiento en relaci¨®n con la rotaci¨®n del jugador (espacio local)
        Vector3 moveRelative = transform.TransformDirection(move) * playerSpeed * Time.deltaTime;

        // Mover el jugador usando MovePosition para evitar acumulaci¨®n de fuerzas
        rb.MovePosition(rb.position + moveRelative);

        // Desbloquear el cursor cuando se presiona Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("checkpoint"))
        {
            warningText.text = "MATAR TODOS LOS ZOMBIE PARA TERMINAR EL LEVEL!";
            warningText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("checkpoint"))
        {
            warningText.enabled = false;
        }
    }
}
