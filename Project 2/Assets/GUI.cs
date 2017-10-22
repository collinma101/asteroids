using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    private ShipCollision shipScript;
    private SmallAsteroidDetection asrtoidSmallScript;
    private BigAsteroidDetection asrtoidBigScript;
    public TextMesh HPText;
    private int hp;
    public TextMesh scoreText;
    private int score1;
    private int score2;
    private int totalscore;
    public TextMesh gameOverText;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        shipScript = GameObject.Find("Scene Manager").GetComponent<ShipCollision>();
        hp = shipScript.shipHP;
        asrtoidSmallScript = GameObject.Find("Scene Manager").GetComponent<SmallAsteroidDetection>();
        asrtoidBigScript = GameObject.Find("Scene Manager").GetComponent<BigAsteroidDetection>();
        score1 = asrtoidSmallScript.totalScore;
        score2 = asrtoidBigScript.totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        PrintScore();
        PrintHP();
        GameOver();

    }
    //displays score and restarts the game
    public void GameOver()
    {
        if (hp <= 0)
        {
            Destroy(player);
            HPText.text = "";
            scoreText.text = "";
            gameOverText.text = "GAME OVER \n PRESS ENTER TO RESTART \n SCORE = " + totalscore;
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(0);
            }
        }
    }
    //shows HP
    public void PrintHP()
    {
        hp = shipScript.shipHP;
        HPText.text = "Health: " + hp;
    }
    //shows score
    public void PrintScore()
    {
        score1 = asrtoidSmallScript.totalScore;
        score2 = asrtoidBigScript.totalScore;
        totalscore = score1 + score2;
        scoreText.text = "Score: " + totalscore;
    }
}
