using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;

public class QA : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Questions;
    [SerializeField] TextMeshProUGUI Answer1;
    [SerializeField] TextMeshProUGUI Answer2;
    [SerializeField] TextMeshProUGUI Answer3;
    [SerializeField] TextMeshProUGUI Answer4;
    [SerializeField] TextMeshProUGUI NamePlayer1;
    [SerializeField] TextMeshProUGUI NamePlayer2;
    [SerializeField] Button ClickedButton1;
    [SerializeField] Button ClickedButton2;
    [SerializeField] Button ClickedButton3;
    [SerializeField] Button ClickedButton4;

    public int QuestionsId = 1;
    public int AnswerId = 1;

    int Player1Score = 0;
    int Player2Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetQuestion(QuestionsId));

        StartCoroutine(GetAnswer(AnswerId));

        NamePlayer1.text = Login.Player1Name;
        NamePlayer2.text = Login.Player2Name;
    }

    IEnumerator GetQuestion(int QuestionsId)
    {
        //UnityWebRequest www = UnityWebRequest.Get("https://localhost:44310/api/GetQuestions?QuestionID=" + QuestionsId + "");
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44310/api/GetQuestions?QuestionID=" + QuestionsId);
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }

        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            Questions.text = www.downloadHandler.text;
        }
    }

    IEnumerator GetAnswer(int AnswerId)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44310/api/GetAnswers?AnswerID=" + AnswerId);
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }

        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            string[] items = www.downloadHandler.text.Trim('[', ']').Split(',');
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = items[i].Trim('"');
            }

            Answer1.text = items[0];
            Answer2.text = items[1];
            Answer3.text = items[2];
            Answer4.text = items[3];
        }
    }

    IEnumerator CheckAnswer(int QuestionsId, int AnswerId)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44310/api/GetAnswers?AnswerID=" + AnswerId);
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }

        else
        {
            // Show results as text
            //Debug.Log(www.downloadHandler.text);

            string[] items = www.downloadHandler.text.Trim('[', ']').Split(',');
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = items[i].Trim('"');
            }

            Answer1.text = items[0];
            Answer2.text = items[1];
            Answer3.text = items[2];
            Answer4.text = items[3];

            if (ClickedButton1.tag == "1")
            {
                if (ClickedButton1.GetComponentInChildren<TextMeshProUGUI>().text == items[0])
                {
                    Debug.Log(items[0]);

                    QuestionsId += 1;
                    StartCoroutine(GetQuestion(QuestionsId));

                    AnswerId += 1;
                    StartCoroutine(GetAnswer(AnswerId));

                    if (tag == "1")
                    {
                        StartCoroutine(Score.UpdateScorePlayer1(Player1Score += 1));
                    }

                    else if(tag == "2")
                    {
                        StartCoroutine(Score.UpdateScorePlayer2(Player2Score += 1));
                    }
                }
            }

            if (ClickedButton2.tag == "2")
            {
                if (ClickedButton2.GetComponentInChildren<TextMeshProUGUI>().text == items[0])
                {
                }
            }

            if (ClickedButton3.tag == "3")
            {
                if (ClickedButton3.GetComponentInChildren<TextMeshProUGUI>().text == items[0])
                {
                }
            }

            if (ClickedButton4.tag == "4")
            {
                if (ClickedButton4.GetComponentInChildren<TextMeshProUGUI>().text == items[0])
                {
                }
            }
        }
    }

    public void PlayerAnswer()
    {
        if (AnswerId == 4)
        {
            return;
        }

        StartCoroutine(CheckAnswer(QuestionsId, AnswerId));

        AnswerId += 1;

        QuestionsId += 1;
    }
}
