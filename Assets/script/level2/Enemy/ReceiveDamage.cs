using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReceiveDamage : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject deadBodyPrefab;
    public int health;
    public TextMeshProUGUI enemyHealthUI;
    public GameController gamecontroller;

    // Update is called once per frame

    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {

    //        //Destroy(gameObject);
    //        //GameObject deadBody = Instantiate(deadBodyPrefab, transform.position, transform.rotation);
    //        Destroy(collision.gameObject);
    //        health -= 25;


    //        if (health <= 0)
    //        {
    //            Debug.Log("Muere");
    //            Destroy(gameObject);
    //        }


    //}
    //}
    private void Start()
    {
        UpdateUI();
        gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    private void UpdateUI()
    {
        enemyHealthUI.text = health.ToString();
    }

    public void ChangeHealth(int damege)
    {
        health -= damege;
        UpdateUI();

        if (health <= 0)
        {
            Debug.Log("Muere");
            Death();
        }
    }

    private void Death()
    {
        gamecontroller.AddKill();
        Destroy(gameObject);
    }
}

