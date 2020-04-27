using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI textToShow;
    public ballMovement ball;
    public GameManager game;
    public int force;
    public int pinesStanding;
    public int ballNumber;
    
    void Start()
    {
        textToShow = gameObject.GetComponent <TextMeshProUGUI>();
        ball = FindObjectOfType<ballMovement>();
        game = FindObjectOfType<GameManager>();

        force = (int)ball.force;
        ballNumber = ball.ballNum;
        pinesStanding = game.pineAmount;
        
        textToShow.text = "Force: " + (force/100) + "\nPines: " + pinesStanding + "\nShotsLeft: " + (4-ballNumber);
    }
    private void Update()
    {
        force = (int)ball.force;
        ballNumber = ball.ballNum;
        pinesStanding = game.pineAmount;
        textToShow.text = "Force: " + (force / 100) + "\nPines: " + pinesStanding + "\nShotsLeft: " + (4 - ballNumber);
    }
}
