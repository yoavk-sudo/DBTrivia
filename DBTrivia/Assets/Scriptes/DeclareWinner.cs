using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeclareWinner : MonoBehaviour
{

    public static int PlayerFinished = 0;

    // Update is called once per frame
    void Update()
    {
        if(PlayerFinished == 2)
        {
            SceneManager.LoadScene(3);
        }
    }
}
