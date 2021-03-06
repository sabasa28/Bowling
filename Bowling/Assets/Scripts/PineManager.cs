﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineManager : MonoBehaviour
{
    public GameObject floor;
    Transform childTrans;
    public bool standing = true;
    void Start()
    {
        childTrans = transform.GetChild(0);
    }

    void Update()
    {
        if (Vector3.Angle(childTrans.up,floor.transform.forward) < 45 || Vector3.Angle(childTrans.up, floor.transform.forward) > 135
            || Vector3.Angle(childTrans.up, floor.transform.right) < 45 || Vector3.Angle(childTrans.up, floor.transform.right) > 135
            || childTrans.position.y < -5)
        {
            standing = false;
        }
        if (standing == false) StartCoroutine(DestroyPine());
    }

    IEnumerator DestroyPine()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
