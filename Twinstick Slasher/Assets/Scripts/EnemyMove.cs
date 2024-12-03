using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    private GameObject player;
    public Transform target;
    [SerializeField]
    float attackTime = 1.5f;
    int damage = 3;
    float attackTimer = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        target = player.transform;
        agent.SetDestination(target.position);
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        target = player.transform;
        agent.SetDestination(target.position);

    }

    void OnCollissionEnter(Collision collider)
    {
        if (collider.transform.tag == "Player") 
        {
           collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
           
        }


    }

                   

}
