using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardScript : MonoBehaviour
{
    public GameObject canvas;

    public TextMeshProUGUI ballCount;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI lowScore;

    static public AudioSource ass;

    static public GameObject[,] ball_object_board = new GameObject[7,7];

    static public GameObject plh;

    public GameObject Void;
    public GameObject musicPlayer;

    public GameObject help;

    private void Start()
    {
        if (PlayerPrefs.GetInt("OpenedOnce", 0) == 0)
        {
            help.SetActive(true);
            PlayerPrefs.SetInt("OpenedOnce", 1);
        }
        PieceScript.bs = this;
        ass = GetComponent<AudioSource>();
        plh = new GameObject();

        ball_object_board[0, 0] = plh;
        ball_object_board[1, 0] = plh;
        ball_object_board[0, 1] = plh;
        ball_object_board[1, 1] = plh;

        ball_object_board[5, 0] = plh;
        ball_object_board[5, 1] = plh;
        ball_object_board[6, 0] = plh;
        ball_object_board[6, 1] = plh; 

        ball_object_board[1, 5] = plh;
        ball_object_board[0, 5] = plh;
        ball_object_board[1, 6] = plh;
        ball_object_board[0, 6] = plh; 

        ball_object_board[5, 5] = plh;
        ball_object_board[6, 5] = plh;
        ball_object_board[5, 6] = plh;
        ball_object_board[6, 6] = plh;

        if(PlayerPrefs.GetInt("HighScore") != 0)
        {
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }

        if (PlayerPrefs.GetInt("LowScore") != 0)
        {
            lowScore.text = PlayerPrefs.GetInt("LowScore").ToString();
        }
    }
    public void UpdateScore()
    {
        ballCount.text = (Int32.Parse(ballCount.text) - 1).ToString();
    }

    public void GameEnd()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        lowScore.text = PlayerPrefs.GetInt("LowScore").ToString();
        canvas.SetActive(true);
    }

    public void TrueGameEnd()
    {
        Void.SetActive(true);
        GameObject.Destroy(musicPlayer);
    }
}
