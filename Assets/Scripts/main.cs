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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.transform.Translate(speed * Time.deltaTime, 0, 0);
        Vector3 up = new Vector3(0.0f, jumpheight, 0.0f);

       

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(up);
            print("Slingshot:OnMouseEnter()");
        }
    }
}
