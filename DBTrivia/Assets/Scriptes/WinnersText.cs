using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinnersText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Annoncment;


    // Start is called before the first frame update
    void Start()
    {
        if(QA.Player1Score > QA.Player2Score)
        {
            Annoncment.text = Login.Player1Name + " Won " + Login.Player2Name;
        }

        if (QA.Player1Score < QA.Player2Score)
        {
            Annoncment.text = Login.Player2Name + " Won " + Login.Player1Name;
        }

        if (QA.Player1Score == QA.Player2Score)
        {
            Annoncment.text = Login.Player1Name + " tie with " + Login.Player2Name;
        }
    }

}
