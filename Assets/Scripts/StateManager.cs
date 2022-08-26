using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum gameState
{
    PLAY,
    GAME_OVER
}


public class StateManager : MonoBehaviour
{
    public static StateManager i = null;
    public GameObject gameOverPanel;


    gameState curGameState = gameState.PLAY;

    void Start()
    {
        if (i == null)
        {
            i = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (curGameState == gameState.GAME_OVER)
        //{
        //    if (Input.GetKey(KeyCode.X))
        //    {
        //        curGameState = gameState.PLAY;
        //    }
        //}
        
    }

    public void setGameState (gameState flag)
    {
        if (flag == gameState.GAME_OVER)
        {
            curGameState = gameState.GAME_OVER;
            gameOverPanel.SetActive(true);
        }
    }

    public gameState getGameState()
    {
        return curGameState;
    }
}
