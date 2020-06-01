using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Turret turret;
    float timer;
    private void Start()
    {
        turret = FindObjectOfType<Turret>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5) 
        {
            turret.shotNum++;
            Destroy(gameObject);
        }
    }
}
