using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
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
        //rib.velocity = rib.velocity / .99;
        if( transform.position.y < .06)
        {
            gameObject.transform.position = new Vector3(transform.position.x, .06f, transform.position.z);
        }
    }

    //public void ontriggerenter(Collider other)
    //{
    //    Debug.Log("here one");
    //    //if (other.gameobject.comparetag("putter"))
    //    //{
    //    //    var magnitude = 5;
    //    //    var force = transform.position - other.transform.position;

    //    //    force.normalize();
    //    //    rib.addforce(force * magnitude);
    //    //}
    //    if (other.gameObject.CompareTag("putter"))
    //    {
    //        Debug.Log("here two");
    //        // calculate force vector
    //        var forcex = transform.position.x - other.transform.position.x;
    //        var forcez = transform.position.z - other.transform.position.z;
    //        // normalize force vector to get direction only and trim magnitude
    //        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(forcex, 0f, forcez));

    //    }
    //}


    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("putterHed"))
        {

            Debug.Log("YOO");
            //// calculate force vector
            //var forcex = transform. - other.transform.position;
            // normalize force vector to get direction only and trim magnitude
            var parent = other.transform.parent.gameObject;
            var putter = other.gameObject;
            var filter = putter.GetComponent<MeshFilter>();
            var vector = filter.transform.TransformDirection(filter.mesh.normals[0]);

            //var direction = new Vector3(parent.transform.rotation.y + 90, 0, parent.transform.rotation.y) ;
            var direction = new Vector3(vector.x, 0, vector.z);
            Debug.Log(other.relativeVelocity);
            Debug.Log(other.relativeVelocity.magnitude);
            var otherColSpeed = Vector3.Dot(-vector, other.relativeVelocity + rib.velocity);
            rib.AddForce(direction * other.relativeVelocity.magnitude * 500);

        }
        else if (other.gameObject.CompareTag("putter"))
        {
            //Vector3 colNormal = (other.transform.position - transform.position).normalized;
            Vector3 colNormal = (other.contacts[0].point - transform.position).normalized;

            float ballColSpeed = Vector3.Dot(colNormal, rib.velocity);
            if (ballColSpeed < 0) { ballColSpeed = 0; }

            float otherColSpeed = 0f;

            if (other.relativeVelocity.magnitude > ballColSpeed)
            {
                otherColSpeed = Vector3.Dot(-colNormal, other.relativeVelocity + rib.velocity);
            }
            rib.AddForce(colNormal * otherColSpeed);
        }
    }

}
