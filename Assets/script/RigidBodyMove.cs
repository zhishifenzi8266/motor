using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RigidBodyMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float jumpForce;
    public Vector2 inputVector;
    public Rigidbody rigidBody;
    public Vector3 velocity;
    public float velocityMagnitude;
    public bool CanJump;
    public Collision contraQueChoque;
    public int collectedItems;
    public TMPro.TextMeshProUGUI scoreText;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        CanJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        rigidBody.AddForce(inputVector.x * speed, 0f, inputVector.y * speed, ForceMode.Impulse);
        
        velocity = rigidBody.velocity;
        velocityMagnitude = velocity.magnitude;

        if(Input.GetKeyDown(KeyCode.Space) && CanJump){
            rigidBody.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            CanJump = false;    
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Choque Contra:" + collision.gameObject.name);

        if(collision.gameObject.tag == "Ground")
        {
            CanJump = true;
        }

        if (collision.gameObject.CompareTag("killzone"))
        {
            Debug.Log("kill!");
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.CompareTag("win"))
        {
            Debug.Log("win!");
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("Item!");
            Destroy(collision.gameObject);  
            collectedItems++;
            scoreText.text = collectedItems.ToString();
        }
    }
}
