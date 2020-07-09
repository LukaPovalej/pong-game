using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    bool  gamepaused;
    Rigidbody2D ball;
    int player1Score = 0;
    int player2Score = 0;
    int roundCount = 0;
    GameObject scoreboard;

    public float maxSpeed = 200f;//Replace with your max speed
    float delay = 3f;

    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        scoreboard = GameObject.FindWithTag("Scoreboard");
        scoreboard.SetActive(false);
        pushBall();
        gamepaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!gamepaused) return;

            scoreboard.SetActive(false);
            pushBall();
            Time.timeScale = 1f;
            gamepaused = false;
            
        }
    }
    void FixedUpdate()
   {
         if(GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
         {
                GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
         }
   }
    void pushBall()
    {
        if (roundCount % 2 == 0)
        {
            ball.velocity = new Vector3(1f * 35f, 0, 0);
        }
        else
        {
            ball.velocity = new Vector3(-1f * 35f, 0, 0);
        }
    }

    public void changeP1Score(int amount)
    {
        player1Score += amount;
        resetAndPrintCurrentStatus();
    }

    public void changeP2Score(int amount)
    {
        player2Score += amount;
        resetAndPrintCurrentStatus();
    }

    void resetAndPrintCurrentStatus()
    {

        gamepaused = true;

        delay = 3f;

        roundCount++;

        Player1Controller p1 = GameObject.FindWithTag("Player1")
            .GetComponent<Player1Controller>();

        Player2Controller p2 = GameObject.FindWithTag("Player2")
            .GetComponent<Player2Controller>();

        p1.resetPos();
        p2.resetPos();

        transform.position = initialPosition;

        Time.timeScale = 0f;
        scoreboard.SetActive(true);
        GameObject.FindWithTag("Score1")
            .GetComponent<UnityEngine.UI.Text>().text = player1Score + "";

        GameObject.FindWithTag("Score2")
            .GetComponent<UnityEngine.UI.Text>().text = player2Score + "";
    }
}

