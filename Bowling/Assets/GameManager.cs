using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<PineManager> pines = new List<PineManager>();
    public ballMovement ball;
    public int pineAmount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pineAmount = 0;
        for (int i = 0; i < pines.Count; i++)
        {
            if (pines[i]) pineAmount ++;
        }

        if (ball.reset == true)
        {
            ball.resetValues();
        }
    }
}
