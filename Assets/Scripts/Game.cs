﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    // This class will handle all of the general world stuff
    [SerializeField] GameObject m_player1;
    [SerializeField] GameObject m_player2;
    [SerializeField] bool m_bothDead = false;
    [SerializeField] GameObject m_pauseMenu;
    [SerializeField] GameObject m_endMenu;
    [SerializeField] TextMeshProUGUI m_score1Text;
    [SerializeField] TextMeshProUGUI m_score2Text;
    [SerializeField] TextMeshProUGUI m_time1Text;
    [SerializeField] TextMeshProUGUI m_time2Text;

    //Player m_p1;
    //Player m_p2;
    float m_currentSeconds = 0;
    private void Start()
    {
        //m_p1 = m_player1.GetComponent<Player>();
        //m_p2 = m_player2.GetComponent<Player>();
    }

    private void Update()
    {
        //m_bothDead = (!m_p1.Alive && !m_p2.Alive);
        if (m_bothDead)
        {
            EndGame();
        }
        else
        {
            UpdateTime();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void EndGame()
    {
        if (m_endMenu && m_pauseMenu && !m_endMenu.activeInHierarchy)
        {
            m_endMenu.SetActive(true);
            m_pauseMenu.SetActive(false);

            SaveScores();
        }
    }

    private void SaveScores()
    {
        if (PlayerPrefs.HasKey("NumberOfPlayers"))
        {
            PlayerPrefs.SetInt("NumberOfPlayers", PlayerPrefs.GetInt("NumberOfPlayers") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("NumberOfPlayers", 1);
        }

        int numPlayers = PlayerPrefs.GetInt("NumberOfPlayers");
        //int score = (m_player1.Score + m_player2.Score) + m_currentSeconds;
        //PlayerPrefs.SetInt("Score" + numPlayers, score);
        PlayerPrefs.SetInt("Score" + numPlayers, numPlayers);

        List<int> scores = new List<int>();

        for (int i = 1; i <= numPlayers; ++i)
        {
            int s = PlayerPrefs.GetInt("Score" + i);
            scores.Add(s);
            PlayerPrefs.DeleteKey("Score" + i);
        }

        scores.Sort();
        scores.Reverse();

        for (int i = 0; i < scores.Count; ++i)
        {
            PlayerPrefs.SetInt("Score" + (i + 1), scores[i]);
            //if (scores[i] == score)
            //{
            //    PlayerPrefs.SetInt("Placement", i + 1);
            //}
            //print(scores[i]);
        }
    }

    private void StartGame()
    {
        if (m_endMenu && m_pauseMenu)
        {
            m_bothDead = false;
            m_endMenu.SetActive(false);
            m_pauseMenu.SetActive(false);
        }
    }

    private void UpdateScore()
    {
        //m_score1Text.text = m_p1.Score.ToString().PadLeft(5, '0');
        //m_score2Text.text = m_p2.Score.ToString().PadLeft(5, '0');
    }

    private void UpdateTime()
    {
        m_currentSeconds += Time.deltaTime;

        //if (m_player1.Alive)
        //{
        //    int seconds = (m_currentSeconds > 60) ? ((int)m_currentSeconds) % 60 : (int)m_currentSeconds;
        //    int minutes = ((int)m_currentSeconds / 60);
        //    m_time1Text.text = minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
        //}
        //if (m_player2.Alive)
        //{
        //    int seconds = (m_currentSeconds > 60) ? ((int)m_currentSeconds) % 60 : (int)m_currentSeconds;
        //    int minutes = ((int)m_currentSeconds / 60);
        //    m_time2Text.text = minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
        //}
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1.0f;
    }

    public void PauseGame()
    {
        if (!m_bothDead)
        {
            Time.timeScale = 0.0f;
            m_pauseMenu.SetActive(true);
        }
    }

    public void UnPauseGame()
    {
        if (!m_bothDead)
        {
            Time.timeScale = 1.0f;
            m_pauseMenu.SetActive(false);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
