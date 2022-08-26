using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager i = null;
    public int score = 0;
    float timer;

    public TMPro.TextMeshProUGUI scoreCounter;
    void Start()
    {
        if (i == null)
        {
            i = this;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (StateManager.i.getGameState() != gameState.GAME_OVER)
        {
            if (timer > 0.5f)
            {

                score += 5;

                //Reset the timer to 0.
                timer = 0;
            }
            scoreCounter.text = "Score: " + score;
        }
    }

    public void increaseScore(int boost)
    {
        score += boost;
    }
}
