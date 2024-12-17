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
    float attackRange = 2f;
    float attackTimer = 0;
    public float knockbackForce = 250;

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
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (attackTimer >= attackTime && distance <= attackRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
        attackTimer = 0;
    }

    public void knockBack(Vector3 contactPosition, GameObject enemy)
    {
        Debug.Log("Knockback");
        Vector3 direction =    Vector3.Scale(contactPosition - player.transform.position, new Vector3(knockbackForce, 0, knockbackForce)); ;
        enemy.GetComponent<Rigidbody>().AddForce(direction);
    }
}
