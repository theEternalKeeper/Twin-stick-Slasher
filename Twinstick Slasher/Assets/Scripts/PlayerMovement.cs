using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    //speed is public in case later on we want to modify it with a powerup, terrain, etc
    public float speed = 10;
    private float maxSpeedX;
    private float maxSpeedZ;
    private float minSpeedX;
    private float minSpeedZ;
    public float height;

    private Vector3 mousePosition;
    private Vector3 lookDirection;
    private Camera mainCamera;

    public GameObject attack;

    // Start is called before the first frame update
    void Start()
    {
        attack = transform.Find("SwordAttack").gameObject;
        controller = gameObject.GetComponent<CharacterController>();
        rb = gameObject.GetComponent<Rigidbody>();
        height = gameObject.transform.position.y;
        Debug.Log("Player: Height set");
        mainCamera = Camera.main;
        //InvokeRepeating("HeightCheck", 1.0f, 1.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        lookDirection = Input.mousePosition;
        lookDirection.z = mainCamera.transform.position.y - transform.position.y;
        lookDirection = mainCamera.ScreenToWorldPoint(lookDirection);
        transform.forward = lookDirection - transform.position;

        if (Input.GetMouseButtonDown(1))
        {
            attack.GetComponent<WeaponSwing>().Swing();
        }
    }

    void FixedUpdate()
    { 
        maxSpeedX = maxSpeedZ = speed;
        minSpeedX = minSpeedZ = -speed;

        float movementX =  Mathf.Clamp(Input.GetAxis("Horizontal") * speed * Time.deltaTime, minSpeedX, maxSpeedX);
        float movementZ =  Mathf.Clamp(Input.GetAxis("Vertical") * (speed-0.001f) * Time.deltaTime, minSpeedZ, maxSpeedZ);

        Vector3 move = new Vector3(movementX, 0, movementZ);

        controller.Move(move);

        if (gameObject.transform.position.y != height)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, height, gameObject.transform.position.z);
        }

        
    }

    void HeightCheck()
    {
        if (gameObject.transform.position.y == height)
        {
            Debug.Log("Player: Height unchanged");
        }
    }
}
