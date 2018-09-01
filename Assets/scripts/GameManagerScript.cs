using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public enum GameState
    {
        Start_Menu,
        How_To_Play,
        Leaderboard,
        Game_Session,
        Pause,
        End_Game,
        Quit_Game
    };

    public GameState gameState;

    //Track VIP
    public GameObject blueVIP;
    public GameObject redVIP;

    //Winner variables
    public string winningTeam;
    public bool isWinnerFound;

    private static bool isCreated = false;

    void Awake()
    {
        if (!isCreated)
        {
            DontDestroyOnLoad(this.gameObject);
            isCreated = true;
            isWinnerFound = false;
            winningTeam = "";
            Debug.Log("Awake: " + this.gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        gameState = GameState.Start_Menu;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.Start_Menu:
                break;
            case GameState.How_To_Play:
                break;
            case GameState.Game_Session:
                //find VIP
                blueVIP = GameObject.FindGameObjectWithTag("BlueVIP");
                redVIP = GameObject.FindGameObjectWithTag("RedVIP");

                FindWinner();
                break;
            case GameState.Pause:
                break;
            case GameState.End_Game:
                break;
            case GameState.Quit_Game:
                break;
        }
    }

    void FindWinner()
    {
        if (blueVIP.GetComponent<VIPHealthBar>().VipHealth <= 0f)
        {
            winningTeam = redVIP.GetComponent<VIPMovement>().VIPTeam;
            isWinnerFound = true;
        }

        if (redVIP.GetComponent<VIPHealthBar>().VipHealth <= 0f)
        {
            winningTeam = blueVIP.GetComponent<VIPMovement>().VIPTeam;
            isWinnerFound = true;
        }

        if (isWinnerFound)
        {
            Debug.Log("Winning Team: " + winningTeam);
            gameState = GameState.End_Game;
        }
    }

    #region Accessors

    public GameState CurrentGameState
    {
        get
        {
            return gameState;
        }

        set
        {
            gameState = value;
        }
    }

    #endregion
}
