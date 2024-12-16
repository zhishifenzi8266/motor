using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int kills;
    private int totalEnemies;

    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;

    void Start()
    {
        winText.enabled = false;
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);

        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        restartButton.onClick.AddListener(RestartGame);
        menuButton.onClick.AddListener(ReturnToMenu);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
    }

    public void AddKill()
    {
        kills++;
        UpdateUI();

        if (kills >= totalEnemies)
        {
            Win();
        }
    }

    public void UpdateUI()
    {
        killsText.text = kills.ToString() + " / " + totalEnemies.ToString();
    }

    private void Win()
    {
        winText.enabled = true;
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0); // 假设菜单场景的索引为0
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
