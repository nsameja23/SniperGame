using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonAction : MonoBehaviour
{
    public string buttonName;
    public GameManagerScript gameManagerScript;

    // Use this for initialization
    void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene()
    {
        buttonName = this.gameObject.tag;

        switch (buttonName)
        {
            case "StartButton":
                gameManagerScript.CurrentGameState = GameManagerScript.GameState.Game_Session;
                SceneManager.LoadScene(1);
                break;
            case "HowToPlayButton":
                gameManagerScript.CurrentGameState = GameManagerScript.GameState.How_To_Play;
                break;
            case "LeaderboardButton":
                gameManagerScript.CurrentGameState = GameManagerScript.GameState.Leaderboard;
                break;
            case "QuitButton":
                gameManagerScript.CurrentGameState = GameManagerScript.GameState.Quit_Game;
                break;
        }
    }

}
