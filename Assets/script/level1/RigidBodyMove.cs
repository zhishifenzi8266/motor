using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
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
    public int totalItems;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI warningText;
    void Start()
    {
        totalItems = GameObject.FindGameObjectsWithTag("Item").Length;
        warningText.enabled = false;
        rigidBody = GetComponent<Rigidbody>();
        CanJump = true;
        scoreText.text = "score:" + collectedItems + "|" + totalItems;
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
            scoreText.GetComponent<TMP_Text>().text = "score: " + collectedItems.ToString();
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            warningText.text = "check point touched";
            warningText.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter:" + other.gameObject.name);
        if (!other.gameObject.CompareTag("Item"))
        {
        }
        else
        {
            Destroy(other.gameObject);
            collectedItems++;
            //scoreText.GetComponent<TMP_Text>().text = "score: " + collectedItems.ToString();
            //scoreText.text = collectedItems.ToString();
            scoreText.text = "score:" + collectedItems + "|" + totalItems;
        }
        if (other.gameObject.CompareTag("checkpoint"))
        {
            warningText.enabled = true;
        }

        if (other.gameObject.CompareTag("checkpoint"))
        {
            warningText.text = "Press E to Save";
            warningText.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit:" + other.gameObject.name);
        warningText.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger Stay:" + other.gameObject.name);
        //collectedItems++;
        //scoreText.text = collectedItems.ToString();
     
    }
}
