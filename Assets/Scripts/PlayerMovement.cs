using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For camera to follow the player drag the camera onto player 
// then it automatically follows the player
public class PlayerMovement : MonoBehaviour
{

    //RigigBody has all the properties such as mass, gravity, etc and falls down
    Rigidbody rb;

    // SerializeField Enables the variable change in unity (variables are also visible in unity editor)
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    // add groundCheck gameObject, and in unity connect the Transform with groundCheck Object
    [SerializeField] Transform groundCheck;

    //Layer is added to Floor Prefabs to enable groundCheck
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the rb object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //automatically handles + and -
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }


    // To check whether the player is touching ground or not
    bool IsGrounded()
    {
        // position, radius of small sphere in the bottom, layermask (floor)
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
