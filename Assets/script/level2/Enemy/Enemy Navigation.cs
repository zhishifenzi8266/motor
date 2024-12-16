using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Player;
    public float initialDelay;
    public float interval;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("SetDestination", initialDelay, interval); //每几秒查看玩家位置
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    SetDestination();
        //}
    }

    public void SetDestination()
    {
        Debug.Log("ser destination: " + Player.position);
        agent.destination = Player.position;
    }
}
