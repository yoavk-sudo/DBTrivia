using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class Score : MonoBehaviour
{
    public static IEnumerator UpdateScorePlayer1(int newScore)
    {
        string url = "https://localhost:44310/api/Values?Score=" + newScore + "&IdPlayers=1";
        WWWForm form = new WWWForm();
        form.AddField("Score", newScore);

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.Send();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Network error: " + www.error);
        }
        else
        {
            Debug.Log("Score update response: " + www.downloadHandler.text);
        }
    }
   
    public static IEnumerator UpdateScorePlayer2(int newScore)
    {
        string url1 = "https://localhost:44310/api/Values?Score=" + newScore + "&IdPlayers=2";
        WWWForm form = new WWWForm();
        form.AddField("Score", newScore);

        UnityWebRequest www = UnityWebRequest.Get(url1);

        yield return www.Send();


        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }

        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
        }
    }
}
