using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Data;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] TMP_InputField Player2;
    [SerializeField] GameObject WaitText;

    public static string Player1Name;
    public static string Player2Name;

    public void UpdatePlayerName()
    {
        if (Player2.text != "")
        {
            StartCoroutine(PlayerStatus());
        }

        StartCoroutine(CourntineUpdatePlayerName(Player2.text));

        Player2Name = Player2.text;

        WaitText.SetActive(true);
    }

    IEnumerator PlayerStatus()
    {
        string url = "https://localhost:44310/api/Values?PlayerState2=1";
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

    IEnumerator CourntineUpdatePlayerName(string Name2)
    {
        string encodedName2 = Uri.EscapeDataString(Name2);

        string url = "https://localhost:44310/api/Values?name2=" + encodedName2;
        UnityWebRequest www = UnityWebRequest.Get(url);

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
