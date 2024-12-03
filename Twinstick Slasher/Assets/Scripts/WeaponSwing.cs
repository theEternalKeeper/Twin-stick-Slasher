using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwing : MonoBehaviour
{
    private Transform player;
    private GameObject hurtbox;
    public float swingSpeed = 1f;
    Vector3 startPosition;
    Quaternion startRotation;
    float swingTime = 0.25f;
    float swingTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
        player = gameObject.GetComponentInParent<Transform>();
        hurtbox = transform.Find("Attack").gameObject;
        startPosition = hurtbox.transform.localPosition;
        hurtbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hurtbox.activeInHierarchy)
        {
            transform.RotateAround(player.position, Vector3.up, swingSpeed);
            swingTimer += Time.deltaTime;
            if (swingTimer >= swingTime)
            {
                hurtbox.SetActive(false);
                swingTimer = 0f;
                transform.localRotation = startRotation;
            }
        }
    }

    public void Swing()
    {
        hurtbox.transform.localPosition = startPosition;
        hurtbox.SetActive(true);
        startPosition = hurtbox.transform.localPosition;
    }
}
