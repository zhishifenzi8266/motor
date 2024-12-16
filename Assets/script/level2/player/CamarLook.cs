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

    private float rotationX = 0f; // Control de la rotación vertical (mirar arriba/abajo)
    private float rotationY = 0f; // Control de la rotación horizontal (girar jugador)

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

        // Acumular la rotación vertical
        rotationX -= smoothV.y;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);  // Limitar la rotación vertical a -90?y 90?

        // Acumular la rotación horizontal
        rotationY += smoothV.x;

        // Aplicar la rotación vertical a la cámara
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Aplicar la rotación horizontal al jugador
        player.transform.localRotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
