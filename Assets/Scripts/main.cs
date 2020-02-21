using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class main : MonoBehaviour
{
    public float speed;
    public float jumpheight;
    public GameObject jiguanprefab;
    public GameObject pickup;
    public float secondsBetweenjiguan;
    public Text scoresText;

    private Rigidbody rb;
    private bool isGrounded;
    private int points;


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
        GameObject pickups = Instantiate<GameObject>(pickup);
        for (int i = 0; i < 10; i++)
        {
            float angle = i * Mathf.PI * 2f / 12;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * 8f + jiguan.transform.position.x, Mathf.Sin(angle) * 8f -9.0f, 0f);
            Instantiate(pickup, newPos, Quaternion.identity);
        }
        Invoke("jiguan", secondsBetweenjiguan);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            points = points + 100;
            scoresText.text = "Scores: " + points.ToString();
            if (points > HighScore.score)
            {
                HighScore.score = points;
            }
        }
    }
}
