using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI textToShow;
    public ballMovement ball;
    public Turret turret;
    public GameManager game;
    public int force;
    public int pinesStanding;
    public int ballNumber;
    public int shotNumber;
    
    void Start()
    {
        textToShow = gameObject.GetComponent <TextMeshProUGUI>();
        ball = FindObjectOfType<ballMovement>();
        game = FindObjectOfType<GameManager>();
        turret = FindObjectOfType<Turret>();

        force = (int)ball.force;
        ballNumber = ball.ballNum;
        shotNumber = turret.shotNum;
        pinesStanding = game.pineAmount;

        textToShow.text = "Force: " + (force / 100) + "\nPines: " + pinesStanding + "\nThrowsLeft: " + (4 - ballNumber) + "\nShotsLeft " + (4 - shotNumber);
    }
    private void Update()
    {
        force = (int)ball.force;
        ballNumber = ball.ballNum;
        shotNumber = turret.shotNum;
        pinesStanding = game.pineAmount;
        textToShow.text = "Force: " + (force / 100) + "\nPines: " + pinesStanding + "\nThrowsLeft: " + (4 - ballNumber) + "\nShotsLeft " + (4 - shotNumber);
    }
}
