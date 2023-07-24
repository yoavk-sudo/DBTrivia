using System;
using TMPro;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player1TimerText;
    [SerializeField] TextMeshProUGUI player2TimerText;
    float player1Timer;
    float player2Timer;
   
    public event Action onPlayer1ReachZero;
    public event Action onPlayer2ReachZero;

    private void Awake()
    {
        TimePointsHolder.player1TimePoints = 0;
        TimePointsHolder.player2TimePoints = 0;

    }
    private void decreaseTimers()
    {
        if (player1Timer > 0)
        {
            player1Timer -= Time.deltaTime;
            if (player1Timer <= 0)
            {
                player1Timer = 0;
                onPlayer1ReachZero.Invoke();
            }
        }


        if (player2Timer > 0)
        {
            player2Timer -= Time.deltaTime;
            player2Timer -= Time.deltaTime;
            if (player2Timer <= 0)
            {
                player2Timer = 0;
                onPlayer2ReachZero.Invoke();

            }
        }

    }

    private void updateTextFields()
    {
        player1TimerText.text = "Time: " + player1Timer;
        player2TimerText.text = "Time: " + player2Timer;

    }


    public void SetPlayer1Time(float _newTime)
    {
        player1Timer = _newTime;
    }

    public void SetPlayer2Time(float _newTime)
    {
        player2Timer = _newTime;
    }

    public void Player1UpdatePoints()
    {
        TimePointsHolder.player1TimePoints += player1Timer;
        
    }

    public void Player2UpdatePoints()
    {
        TimePointsHolder.player2TimePoints += player2Timer;
    }
    void Update()
    {
        decreaseTimers();
        updateTextFields();
    }
}
