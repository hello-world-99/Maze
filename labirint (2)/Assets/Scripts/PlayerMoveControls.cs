using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControls : MonoBehaviour {
    private Rigidbody2D compRb;
    private Camera cam;
    public float speed = 2;
    // Use this for initialization
    private void Start ()
    {
        compRb = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	private void Update ()
    {
        compRb.velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            compRb.velocity+=Vector2.left*speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            compRb.velocity += Vector2.down * speed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            compRb.velocity += Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            compRb.velocity += Vector2.right * speed;
        }
    }
}
