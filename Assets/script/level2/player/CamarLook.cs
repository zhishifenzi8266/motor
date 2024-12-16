using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    Vector2 smoothV;

    public Vector2 mouseInput;

    public float sensibility = 5f;
    public float smooth = 2f;

    public GameObject player;

    private float rotationX = 0f; // Control de la rotaci�n vertical (mirar arriba/abajo)
    private float rotationY = 0f; // Control de la rotaci�n horizontal (girar jugador)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el cursor en el centro de la pantalla
        player = this.transform.parent.gameObject;
    }

    void Update()
    {
        // Obtener la entrada del mouse
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // Aplicar sensibilidad y suavizado
        mouseInput = Vector2.Scale(mouseInput, new Vector2(sensibility * smooth, sensibility * smooth));

        // Suavizar el movimiento del mouse
        smoothV.x = Mathf.Lerp(smoothV.x, mouseInput.x, 1f / smooth);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseInput.y, 1f / smooth);

        // Acumular la rotaci�n vertical
        rotationX -= smoothV.y;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);  // Limitar la rotaci�n vertical a -90?y 90?

        // Acumular la rotaci�n horizontal
        rotationY += smoothV.x;

        // Aplicar la rotaci�n vertical a la c�mara
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Aplicar la rotaci�n horizontal al jugador
        player.transform.localRotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
