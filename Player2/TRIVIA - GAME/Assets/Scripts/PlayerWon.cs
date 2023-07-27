using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerWon : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Annoncment;

    // Start is called before the first frame update
    void Start()
    {
        Annoncment.text = QA.PlayerWon;
    }
}
