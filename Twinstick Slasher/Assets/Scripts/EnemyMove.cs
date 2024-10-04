using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    private GameObject player;
    public Transform target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        target = player.transform;
        agent.destination = target.position;
    }

    void Update()
    {
        if (target.position != player.transform.position)
        {
            target = player.transform;
            agent.destination = target.position;
        }   
    }
}
