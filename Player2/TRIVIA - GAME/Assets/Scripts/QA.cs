using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QA : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Questions;
    [SerializeField] TextMeshProUGUI Answer1;
    [SerializeField] TextMeshProUGUI Answer2;
    [SerializeField] TextMeshProUGUI Answer3;
    [SerializeField] TextMeshProUGUI Answer4;
    [SerializeField] TextMeshProUGUI NamePlayer2;
    [SerializeField] TextMeshProUGUI ScorePlayer2;
    [SerializeField] Button ClickedButton1;
    [SerializeField] Button ClickedButton2;
    [SerializeField] Button ClickedButton3;
    [SerializeField] Button ClickedButton4;

    public int QuestionsId = 1;
    public int AnswerId = 1;
    public int SumTime;

    public static int Player1Score = 0;
    public static int Player2Score = 0;
    public static string PlayerWon;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetQuestion(QuestionsId));

        StartCoroutine(GetAnswer(AnswerId));

        NamePlayer2.text = Login.Player2Name;
    }

    private void Update()
    {
        StartCoroutine(Score.CheckFinish());

        if (QuestionsId == 5)
        {
            StartCoroutine(Score.UpdateFinish(2));
        }
    }

    public IEnumerator GetQuestion(int QuestionsId)
    {
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

        if (QuestionsId == 5 && Score.FinishedGame == 1)
        {
            if (Score.NumberPlayer1Score > Score.NumberPlayer2Score)
            {
                SceneManager.LoadScene(3);

                PlayerWon = "Lose";
            }

            if (Score.NumberPlayer1Score == Score.NumberPlayer2Score)
            {
                if (Score.TimeNumber1 < Score.TimeNumber2)
                {
                    PlayerWon = "Lose";

                    SceneManager.LoadScene(3);
                }

                else if (Score.TimeNumber1 > Score.TimeNumber2)
                {
                    PlayerWon = "Won";

                    SceneManager.LoadScene(3);
                }

                else
                {
                    PlayerWon = "Tie";

                    SceneManager.LoadScene(3);
                }
            }

            if (Score.NumberPlayer1Score < Score.NumberPlayer2Score)
            {
                SceneManager.LoadScene(3);

                PlayerWon = "Won";
            }
        }
    }

    public IEnumerator GetAnswer(int AnswerId)
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

            GameObject clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            string clickedTag = clickedButton.tag;

            if (clickedButton.CompareTag(clickedTag))
            {
                switch (clickedTag)
                {
                    case "1":
                        if (clickedButton.GetComponentInChildren<TextMeshProUGUI>().text == items[0])
                        {
                            QuestionsId += 1;
                            StartCoroutine(GetQuestion(QuestionsId));

                            AnswerId += 1;
                            StartCoroutine(GetAnswer(AnswerId));

                            if (tag == "2")
                            {
                                StartCoroutine(Score.UpdateScorePlayer2(Player2Score += 1));

                                ScorePlayer2.text = Player2Score.ToString();
                            }

                            ClickedButton1.image.color = Color.green;

                            yield return new WaitForSeconds(1);

                            ClickedButton1.image.color = Color.white;
                        }

                        break;

                    case "2":
                        QuestionsId += 1;
                        StartCoroutine(GetQuestion(QuestionsId));

                        AnswerId += 1;
                        StartCoroutine(GetAnswer(AnswerId));

                        if (tag == "2")
                        {
                            StartCoroutine(Score.UpdateScorePlayer2(Player2Score));

                            ScorePlayer2.text = Player2Score.ToString();
                        }

                        ClickedButton2.image.color = Color.red;

                        yield return new WaitForSeconds(1);

                        ClickedButton2.image.color = Color.white;

                        break;

                    case "3":
                        QuestionsId += 1;
                        StartCoroutine(GetQuestion(QuestionsId));

                        AnswerId += 1;
                        StartCoroutine(GetAnswer(AnswerId));

                        if (tag == "2")
                        {
                            StartCoroutine(Score.UpdateScorePlayer2(Player2Score));

                            ScorePlayer2.text = Player2Score.ToString();
                        }

                        ClickedButton3.image.color = Color.red;

                        yield return new WaitForSeconds(1);

                        ClickedButton3.image.color = Color.white;

                        break;

                    case "4":
                        QuestionsId += 1;
                        StartCoroutine(GetQuestion(QuestionsId));

                        AnswerId += 1;
                        StartCoroutine(GetAnswer(AnswerId));

                        if (tag == "2")
                        {
                            StartCoroutine(Score.UpdateScorePlayer2(Player2Score));

                            ScorePlayer2.text = Player2Score.ToString();
                        }

                        ClickedButton4.image.color = Color.red;

                        yield return new WaitForSeconds(1);

                        ClickedButton4.image.color = Color.white;

                        break;
                }
            }
        }
    }

    public void PlayerAnswer()
    {
        if (AnswerId == 5)
        {
            if (tag == "1")
            {
                ClickedButton1.enabled = false;
                ClickedButton2.enabled = false;
                ClickedButton3.enabled = false;
                ClickedButton4.enabled = false;
            }

            if (tag == "2")
            {
                ClickedButton1.enabled = false;
                ClickedButton2.enabled = false;
                ClickedButton3.enabled = false;
                ClickedButton4.enabled = false;
            }

            return;
        }

        StartCoroutine(CheckAnswer(QuestionsId, AnswerId));
        StartCoroutine(Score.UpdatTime(SumTime));
        AnswerId += 1;
        QuestionsId += 1;

        SumTime += (int)Timer.PlayerTimer;
        Timer.PlayerTimer = 10;
    }
}
