using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 newposition;
    public float speed;
    public Vector2 inputVector;
    void Start()
    {
        Debug.Log("game start");

        transform.position = newposition;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("gamerunning");
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        transform.Translate(inputVector.x * speed, 0f, inputVector.y * speed);

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("key p pressed");
            transform.position = newposition;
        }
    }
}
