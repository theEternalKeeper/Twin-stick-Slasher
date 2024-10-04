using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private GameObject player;
    public Transform target;
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        target = player.transform;
        agent.destination = target.position;
    }

    void Update()
    {

    }
}
