using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private float currentHealth = 1;

    [SerializeField]
    private float baseHealth = 5;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = baseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
           Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void OnTriggerEnter (Collider collider)
    {
        Debug.Log("Collision detected");
        if (collider.gameObject.CompareTag("PlayerAttack"))
        {
            Debug.Log("Damage taken");
            TakeDamage(1);
        }
    }
}
