using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    //public Text hiScoreText;   // To add highscore, similar declarations to scoreText

    public float scoreCount = 1;

    public float pointsPerSecond;

    public bool scoreIncreasing; // So score doesn't increase once dead

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveorb.isDead)
        {
            if (scoreIncreasing)
            {
                scoreCount += pointsPerSecond * Time.deltaTime;
            }
        }
        scoreText.text = "Score: " + (int)scoreCount;
    }
}
