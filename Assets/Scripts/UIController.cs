using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreText;
    public Text HighscoreText;

    public GameObject GameOverPanel;
    public GameObject StartGamePanel;
    public GameObject SettingsPanel;
    public GameObject UIContainer;
    public GameObject BackgroundImage;

    public void Start()
    {
        BackgroundImage.SetActive(true);
        HideGameOver();
        HideSettingsPanel();
        HideUI();
        ShowStartGamePanel();
        
    }
    public void UpdateScoreText(int _value)
    {
        ScoreText.text = _value.ToString();
    }

    public void ResetScoreText()
    {
        ScoreText.text = "Score";
    }

    public void UpdateHighscoreText(int _value)
    {
        HighscoreText.text = _value.ToString();
    }

    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void HideGameOver()
    {
        GameOverPanel.SetActive(false);
    }

    public void ShowUI()
    {
        UIContainer.SetActive(true);
    }

    public void HideUI()
    {
        UIContainer.SetActive(false);
    }

    public void ShowStartGamePanel()
    {
        StartGamePanel.SetActive(true);
    }

    public void HideStartGamePanel()
    {
        StartGamePanel.SetActive(false);
    }
    public void ShowSettingsPanel()
    {
        SettingsPanel.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        SettingsPanel.SetActive(false);
    }
}
