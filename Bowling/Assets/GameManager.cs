using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<PineManager> pines = new List<PineManager>();
    public ballMovement ball;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ball.reset == true)
        {
            for (int i = 0; i < pines.Count; i++)
            {
                if (pines[i])
                    if (pines[i].standing == false) 
                        Destroy(pines[i].gameObject);
            }
            ball.resetValues();
        }
    }
}
