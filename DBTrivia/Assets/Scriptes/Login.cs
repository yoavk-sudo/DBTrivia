using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Data;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Player1;
    [SerializeField] TextMeshProUGUI Player2;

    public void UpdatePlayerName()
    {
        if (!string.IsNullOrEmpty(Player1.text) && !string.IsNullOrEmpty(Player2.text))
        {
            Debug.Log(Player1.text == "noga");
            SceneManager.LoadScene(2);
        }

        StartCoroutine(CourntineUpdatePlayerName(Player1.text, Player2.text));
    }

    [Obsolete]
    IEnumerator CourntineUpdatePlayerName(string Name1, string Name2)
    {
        string encodedName1 = Uri.EscapeDataString(Name1);
        string encodedName2 = Uri.EscapeDataString(Name2);

        string url = "https://localhost:44310/api/Values?name1=" + encodedName1 + "&name2=" + encodedName2;
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
