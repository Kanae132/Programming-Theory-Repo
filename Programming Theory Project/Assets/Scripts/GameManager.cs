using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI score;
    public Button backToMenuBtn;
    public Button resumeBtn;
    public GameObject bulletPrefab;
    private Queue<GameObject> bullets = new Queue<GameObject>();

    private bool isPause = false;
    [SerializeField] private float point = 0;

    void Start()
    {
        playerNameText.text = DataManager.Instance.playerName;
    }

    void Update()
    {
        PauseAndResume();
        ScoreUpdate(0);

    }

    public void ScoreUpdate(float pointToAdd)
    {
        point += pointToAdd;
        score.text = "Score: " + point;
    }

    private void PauseAndResume()
    {
        if (Input.GetKeyDown("p") && isPause == false)
        {
            Time.timeScale = 0;
            Debug.Log("Changed time scale to 0");
            isPause = true;
            backToMenuBtn.gameObject.SetActive(true);
            resumeBtn.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown("p") && isPause)
        {
            Time.timeScale = 1;
            Debug.Log("Changed time scale to 1");
            isPause = false;
            backToMenuBtn.gameObject.SetActive(false);
            resumeBtn.gameObject.SetActive(false);
        }
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        isPause = false;
        backToMenuBtn.gameObject.SetActive(false);
        resumeBtn.gameObject.SetActive(false);
    }



    //object pooling

    //Them dan
    public void AddBullet(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.SetActive(false);
            bullets.Enqueue(newBullet);
        }
    }

    //neu so luong dan = 0, them 1 dan va lay 1 vien dan trong hang doi
    public GameObject GetBullet()
    {
        if (bullets.Count == 0)
        {
            AddBullet(10);
        }

        return bullets.Dequeue();
    }

    //cho nhung vien dan khong hoat va them vao hang doi bullets
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bullets.Enqueue(bullet);
    }
}