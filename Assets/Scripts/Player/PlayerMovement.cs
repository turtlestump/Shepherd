using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Variables
    public Rigidbody2D playerBody;  // This call to the Rigidbody2D object is public so Unity can access it.
    public float speed;
    public float input; // Keeps track of x input (left or right)

    // Update is called once per frame
    void Update() {
        
        // Input should be a button press (i.e. arrow keys)
        input = Input.GetAxisRaw("Horizontal"); // Sets input to read left and right arrow key presses.

    }

    // FixedUpdate locks the player's movement speed to a set framerate to maintain consistency across systems.
    void FixedUpdate() {

        // Vector2s are directional x/y values.
        playerBody.velocity = new Vector2 (input * speed, playerBody.velocity.y); // Controls player speed and ensures the player will maintain momentum in the y direction.

    }

}
