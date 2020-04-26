using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public float force = 0.0f;
    public float movement = 20.0f;
    bool ableToMove = true;
    Vector3 dir;
    float add = 3000.0f;
    Rigidbody rb;
    bool shot=false;
    float minZ = -6;
    float maxZ = 10;
    float maxForce = 15000.0f;
    Vector3 origPos;
    Quaternion origRot;
    public bool reset = false;
    int ballNum = 1;

    void Start()
    {
        origPos = transform.position;
        origRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.z > minZ && ableToMove)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - movement*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.z < maxZ && ableToMove)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movement * Time.deltaTime);
        }
        dir = transform.forward * force;
        if (Input.GetKey(KeyCode.Space) && force<maxForce)
        {
            force+=add*Time.deltaTime;
            if (force > maxForce) force = maxForce;
        }
        if (Input.GetKeyUp(KeyCode.Space) &&shot==false)
        {
            rb.AddForce(dir);
            shot = true;
            ableToMove = false;
        }
        if (transform.position.y < -1)
            reset= true;
    }

    public void resetValues()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.constraints = RigidbodyConstraints.None;
        transform.rotation = origRot; 
        transform.position = origPos;
        rb.velocity = Vector3.zero;
        reset = false;
        force = 0.0f;
        if (ballNum < 3)
        {
            ballNum++;
            shot = false;
            ableToMove = true;
        }
    }
}
