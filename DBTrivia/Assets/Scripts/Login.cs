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
    [SerializeField] TMP_InputField Player1;
    [SerializeField] GameObject WaitText;

    public static string Player1Name;

    public void UpdatePlayerName()
    {
        if (Player1.text != "")
        {
            StartCoroutine(PlayerStatus());
        }

        StartCoroutine(CourntineUpdatePlayerName(Player1.text));

        Player1Name = Player1.text;

        WaitText.SetActive(true);

        //Player2Name = Player2.text;
    }

    IEnumerator PlayerStatus()
    {
        string url = "https://localhost:44310/api/Values?PlayerState1=1";

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.Send();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Network error: " + www.error);
        }
        else
        {
            Debug.Log("Player Status: " + www.downloadHandler.text);
        }
    }

    IEnumerator CourntineUpdatePlayerName(string Name1)
    {
        string encodedName1 = Uri.EscapeDataString(Name1);
        //string encodedName2 = Uri.EscapeDataString(Name2);

        string url = "https://localhost:44310/api/Values?name1=" + encodedName1;
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
