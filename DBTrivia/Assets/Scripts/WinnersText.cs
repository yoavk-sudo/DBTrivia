using TMPro;
using UnityEngine;

public class WinnersText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Annoncment;


    // Start is called before the first frame update
    void Start()
    {
        if (QA.Player1Score > QA.Player2Score)
        {
            Annoncment.text = Login.Player1Name + " Won " + Login.Player2Name;
        }

        if (QA.Player1Score < QA.Player2Score)
        {
            Annoncment.text = Login.Player2Name + " Won " + Login.Player1Name;
        }

        if (QA.Player1Score == QA.Player2Score)
        {
            if (TimePointsHolder.player1TimePoints > TimePointsHolder.player2TimePoints)
            {
                Annoncment.text = Login.Player1Name + " Won " + Login.Player2Name;
            }
            else if (TimePointsHolder.player2TimePoints > TimePointsHolder.player1TimePoints)
            {
                Annoncment.text = Login.Player2Name + " Won " + Login.Player1Name;
            }
            else
            {

                Annoncment.text = Login.Player1Name + " tie with " + Login.Player2Name;
            }
        }

    }

}
