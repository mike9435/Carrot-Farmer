using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotSpeed = 50f;

    public GameObject player;
    public GameObject playerParent;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets Inputs from Input Manager
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        

        //gets direction of movement in relation to what the player inputs
        //Vector3 movementDirection = new Vector3( speed * horizontalInput * Time.deltaTime, 0,  speed * verticalInput * Time.deltaTime );
        //movementDirection.Normalize();

        //moves playerParent left or right and up or down in relation to the player
        //player.transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        // player.transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        //player.transform.localEulerAngles = new Vector3(speed * horizontalInput * Time.deltaTime, 0, speed * verticalInput * Time.deltaTime);

        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            animator.SetBool("isWalking", true);
            player.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey("w"))
        {
                player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(0, -45, 0), rotSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("d"))
        {
                player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(0, 45, 0), rotSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("s"))
        {

            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(0, 135, 0), rotSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("a"))
        {

            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(0, -135, 0), rotSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("d") || Input.GetKey("w"))
        {

            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(0, 0, 0), rotSpeed * Time.deltaTime);
        }

        /*if (movementDirection != Vector3.zero)
        {
            player.transform.rotation = Quaternion.LookRotation(movementDirection);
        }*/


        /*if (horizontalInput != 0 || verticalInput != 0)
        {
            player.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }*/


    }
}
