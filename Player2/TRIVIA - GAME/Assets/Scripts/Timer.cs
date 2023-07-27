using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] QA QA;

    public static float PlayerTimer = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTimer > 0)
        {
            PlayerTimer -= Time.deltaTime;

            TimerText.text = PlayerTimer.ToString("00");

            if (PlayerTimer <= 0 && QA.AnswerId == 4)
            {
                PlayerTimer = 0;

                StartCoroutine(QA.GetAnswer(QA.AnswerId += 1));

                StartCoroutine(QA.GetQuestion(QA.QuestionsId += 1));

                PlayerTimer = 10;
            }
        }
    }
}
