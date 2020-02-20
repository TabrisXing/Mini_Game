﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public float speed;
    public float jumpheight;
    public GameObject jiguanprefab;
    public float secondsBetweenjiguan;

    private Rigidbody rb;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
        Invoke("jiguan", 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.transform.Translate(speed * Time.deltaTime, 0, 0);
        Vector3 up = new Vector3(0.0f, jumpheight, 0.0f);

        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(up);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void jiguan()
    {
        GameObject jiguan = Instantiate<GameObject>(jiguanprefab);
        jiguan.transform.position = new Vector3(transform.position.x + 35.0f, -9.0f, 0f);
        Invoke("jiguan", secondsBetweenjiguan);
    }
}
