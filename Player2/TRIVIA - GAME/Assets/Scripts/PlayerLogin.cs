using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Data;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLogin : MonoBehaviour
{
    [SerializeField] TMP_InputField player;

    public static string playerName;

    public float interval = 2.0f;

    public int Number1;

    public int Number2;

    private void Update()
    {
        StartCoroutine(PlayerConnection());
        StartCoroutine(SecondPlayerConnection());
        // Call MyMethod every 'interval' seconds, starting after 'interval' seconds from now
        //InvokeRepeating("PlayerConnection", interval, interval);
        if (Number1 == 1 && Number2 == 1)
        {
            SceneManager.LoadScene(2);
        }
    }


    IEnumerator PlayerConnection()
    {
        string url = "https://localhost:44310/api/Values?IdPlayers=1";


        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.Send();

        Number1 = int.Parse(www.downloadHandler.text);

        Debug.Log(Number1);

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Network error: " + www.error);
        }
        else
        {
            Debug.Log("Player Two State: " + www.downloadHandler.text);
        }
    }

    IEnumerator SecondPlayerConnection()
    {
        string url = "https://localhost:44310/api/Values?IdPlayers=2";


        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.Send();

        Number2 = int.Parse(www.downloadHandler.text);

        Debug.Log(Number2);

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Network error: " + www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }

    //IEnumerator PlayerStatus(int LogIn)
    //{
    //    string url = "https://localhost:44310/api/Values?PlayerState=" + LogIn;
    //    WWWForm form = new WWWForm();
    //    form.AddField("LogIn", LogIn);

    //    UnityWebRequest www = UnityWebRequest.Get(url);

    //    yield return www.Send();

    //    if (www.isNetworkError || www.isHttpError)
    //    {
    //        Debug.LogError("Network error: " + www.error);
    //    }
    //    else
    //    {
    //        Debug.Log("Score update response: " + www.downloadHandler.text);
    //    }
    //}

    public void UpdatePlayerName()
    {
        if (player.text != "")
        {
           // StartCoroutine(PlayerStatus(1));
        }

        StartCoroutine(CourntineUpdatePlayerName(player.text));

        playerName = player.text;
    }

    IEnumerator CourntineUpdatePlayerName(string Name1)
    {
        string encodedName1 = Uri.EscapeDataString(Name1);

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
