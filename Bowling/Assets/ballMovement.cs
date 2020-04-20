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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
        }
        if (Input.GetKeyUp(KeyCode.Space) &&shot==false)
        {
            rb.AddForce(dir);
            shot = true;
            ableToMove = false;
        }
    }
}
