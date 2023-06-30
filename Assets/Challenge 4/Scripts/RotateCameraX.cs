using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    private float speed = 150;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0;//Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput=-1.0f;
        }else 
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1.0f;
        }
            transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        transform.position = player.transform.position; // Move focal point with player

    }
}
