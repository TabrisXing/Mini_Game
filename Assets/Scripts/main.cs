using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public float speed;
    public float jumpheight;

    private Rigidbody rb;
    private bool groundContact;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = 1;
        Vector3 up = new Vector3(0.0f, jumpheight, 0.0f);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown("space") && groundContact)
        {
            rb.AddForce(up);
            groundContact = false;
        }
    }

    void OnTriggerEnter(Collider coll)
    {

        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Ground")
        {
            groundContact = true;
        }
    }
}
