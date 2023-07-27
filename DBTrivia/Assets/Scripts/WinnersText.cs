using TMPro;
using UnityEngine;

public class WinnersText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Annoncment;


    // Start is called before the first frame update
    void Start()
    {
        Annoncment.text = QA.PlayerWon;
    }

}
