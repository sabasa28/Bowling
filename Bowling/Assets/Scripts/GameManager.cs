using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<PineManager> pines = new List<PineManager>();
    public ballMovement ball;
    public Turret turret;
    public int pineAmount = 0;
    void Update()
    {
        pineAmount = 0;
        for (int i = 0; i < pines.Count; i++)
        {
            if (pines[i]) pineAmount++;
        }

        if (ball.reset == true)
        {
            ball.resetValues();
        }

        if (pineAmount == 0)
        {
            Result.Get().win = true;
            SceneManager.LoadScene(2);
        }

        if (ball.ballNum > 3 && turret.shotNum > 3)
        {
            Result.Get().win = false;
            SceneManager.LoadScene(2);
        }
    }
}
