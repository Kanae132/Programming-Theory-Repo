using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
   
    void Start()
    {
        playerNameText.text = DataManager.Instance.playerName;
    }

   
}
