using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public TMP_InputField inputPlayerName;
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        startButton.onClick.AddListener(SavePlayerName);
    }

    public void SavePlayerName()
    {
        DataManager.Instance.playerName = inputPlayerName.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        //only works in the built application
        Application.Quit();
        #endif
    }

  
}
