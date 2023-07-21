using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class QA : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Questions;
    [SerializeField] TextMeshProUGUI Answer1;
    [SerializeField] TextMeshProUGUI Answer2;
    [SerializeField] TextMeshProUGUI Answer3;
    [SerializeField] TextMeshProUGUI Answer4;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        StartCoroutine(GetQuestion());

        StartCoroutine(GetAnswer());
    }

    [System.Obsolete]
    IEnumerator GetQuestion()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44310/api/GetQuestions?QuestionID={QuestionID}");
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

    [System.Obsolete]
    IEnumerator GetAnswer()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://localhost:44310/api/GetAnswers?AnswerID={AnswerID}");
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
}
