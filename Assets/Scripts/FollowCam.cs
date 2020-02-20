using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject player;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.x - player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        
        transform.position = new Vector3(offset, 9.0f, -10.0f); ;
    }
}
