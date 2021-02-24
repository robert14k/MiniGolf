using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }


    //void OnTriggerEnter(Collider other)
    //{
    //    int force = 3;
    //    if (other.gameObject.CompareTag("putterHead"))
    //    {
    //        // Calculate Angle Between the collision point and the player
    //        Vector3 dir = c.contacts[0].point - transform.position;
    //        // We then get the opposite (-Vector3) and normalize it
    //        dir = -dir.normalized;
    //        // And finally we add force in the direction of dir and multiply it by force. 
    //        // This will push back the player
    //        GetComponent<Rigidbody>().AddForce(dir * force);
    //    }
    //}

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("putterV1"))
        {
            // how much the character should be knocked back
            var magnitude = 5000;
            // calculate force vector
            var force = transform.position - other.transform.position;
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);

        }
    }

}

