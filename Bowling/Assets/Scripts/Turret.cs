using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Camera cam;
    public Transform cannon;
    public GameObject bullet;
    Vector3 targetPoint;
    Vector3 baseTarget;
    Vector3 cannonTarget;
    Quaternion startRot;
    public int shotNum = 1;
    float timer = 0.0f;
    enum State 
    {
        steady,
        movingBase,
        movingCannon,
        shooting,
    }
    State actionState;
    void Start()
    {
        cam = Camera.main;
        cannon = transform.GetChild(0);
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Vector3 mousePos = Input.mousePosition;

        Ray ray = cam.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 200, Color.yellow);


        switch (actionState)
        {
            case State.steady:
                if (Input.GetMouseButtonDown(0) && shotNum <= 3)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 200))
                    {
                        targetPoint = hit.point;
                        baseTarget = new Vector3(targetPoint.x, transform.position.y, targetPoint.z);
                        startRot = transform.rotation;
                        actionState = State.movingBase;
                        timer = 0.0f;
                    }
                }
                break;
            case State.movingBase:
                if (transform.rotation != Quaternion.LookRotation(baseTarget - transform.position))
                {
                    timer += Time.deltaTime;
                    transform.rotation = Quaternion.Slerp(startRot, Quaternion.LookRotation(baseTarget - transform.position), timer);
                }
                else
                {
                    cannonTarget = new Vector3(targetPoint.x, targetPoint.y, targetPoint.z);
                    startRot = cannon.rotation;
                    timer = 0.0f;
                    actionState = State.movingCannon;
                }
                break;
            case State.movingCannon:
                if (cannon.rotation != Quaternion.LookRotation(cannonTarget - transform.position))
                {
                    timer += Time.deltaTime;
                    cannon.rotation = Quaternion.Slerp(startRot, Quaternion.LookRotation(cannonTarget - transform.position), timer);
                }
                else
                {
                    actionState = State.shooting;
                }
                break;
            case State.shooting:
                GameObject go = Instantiate(bullet, transform.position+(cannon.forward*10), cannon.rotation);
                go.GetComponent<Rigidbody>().AddForce(go.transform.forward*3000);
                actionState = State.steady;
                break;
        }

    }
}
