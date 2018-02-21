using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    // This class will handle all of the general world stuff
    [SerializeField] GameObject m_player1;
    [SerializeField] GameObject m_player2;
    [SerializeField] bool m_bothDead = false;
    [SerializeField] GameObject m_pauseMenu;
    [SerializeField] GameObject m_loseMenu;
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
    }

    private void EndGame()
    {
        if (m_loseMenu && m_pauseMenu)
        {
            m_loseMenu.SetActive(true);
            m_pauseMenu.SetActive(false);
        }
    }

    private void StartGame()
    {
        if (m_loseMenu && m_pauseMenu)
        {
            m_bothDead = false;
            m_loseMenu.SetActive(false);
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
}
