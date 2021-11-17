using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RotatingBiofilm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float z = gameObject.transform.position.z;

        float xPos = Random.Range(-0.5f, 0.5f);
        float yPos = Random.Range(-0.5f, 0.5f);
        float zPos = Random.Range(-0.5f, 0.5f);

        float rotationx = Random.Range(-0.1f, 0.1f);
        float rotationy = Random.Range(-0.1f, 0.1f);
        float rotationz = Random.Range(-0.1f, 0.1f);


        rb.AddTorque(new Vector3(0, 0.001f, 0));
        //rb.velocity = new Vector3(xPos, yPos, zPos);
    }
}
