using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_InputField inputPlayerName;
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(SavePlayerName);
    }

    public void SavePlayerName()
    {
        DataManager.Instance.playerName = inputPlayerName.text;
        SceneManager.LoadScene(1);
    }

  
}
