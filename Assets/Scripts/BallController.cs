using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllers : MonoBehaviour
{
    public float speed;
    private Rigidbody rib;
    // Start is called before the first frame update
    void Start()
    {
        rib = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    //public void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("putter"))
    //    {
    //        var magnitude = 5;
    //        var force = transform.position - other.transform.position;

    //        force.Normalize();
    //        rib.AddForce(force * magnitude);
    //    }
    //}

}
