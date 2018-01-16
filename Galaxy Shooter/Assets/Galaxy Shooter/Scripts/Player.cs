using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed = 5.0f;

	// Use this for initialization
	void Start () {

        //current pos = new position
        transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

        // Move the player ship
        Movement();
    }

    private void Movement() {

        // Get player inputs and move ship accordingly
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(speed * horizontalInput, speed * verticalInput, 0) * Time.deltaTime);

        // Enforce vertical player bounds
        if (transform.position.y > 0)
            transform.position = new Vector3(transform.position.x, 0, 0);
        else if (transform.position.y < -4.2f)
            transform.position = new Vector3(transform.position.x, -4.2f, 0);

        // Enforce horizontal player bounds
        if (transform.position.x > 8.0f)
            transform.position = new Vector3(8.0f, transform.position.y, 0);
        else if (transform.position.x < -8.0)
            transform.position = new Vector3(-8.0f, transform.position.y, 0);
    }
}
