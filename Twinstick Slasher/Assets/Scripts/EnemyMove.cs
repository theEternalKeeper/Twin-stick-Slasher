using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    private GameObject player;
    public Transform target;
<<<<<<< Updated upstream
    [SerializeField]
    float attackTime = 1.5f;
    int damage = 3;
    float attackTimer = 0;
=======
    public float knockbackForce = 250;
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
    void OnCollissionEnter(Collision collider)
    {
        if (collider.transform.tag == "Player") 
        {
           collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
           
        }


    }

                   

=======
    public void knockBack(Vector3 contactPosition, GameObject enemy)
    {
        Debug.Log("Knockback");
        Vector3 direction =    Vector3.Scale(contactPosition - player.transform.position, new Vector3(knockbackForce, 0, knockbackForce)); ;
        enemy.GetComponent<Rigidbody>().AddForce(direction);
    }
>>>>>>> Stashed changes
}
