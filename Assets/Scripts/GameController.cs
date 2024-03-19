using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int Score = 0;
    private int HighScore = 0;
    public int Difficulty = 1;
    public int Mode = 0;

    public UIController UIController;
    public SkyboxController SkyboxController;

    public InputField InputField;
    public Dropdown DifficultyDropdown;
    public Dropdown ModeDropdown;

    public bool isPlaying = false;

    private void Update()
    {
        if (isPlaying)
        {
            SkyboxController.TryCreateRaindrop(Difficulty, Mode);
            SkyboxController.CheckInput(InputField.text, Difficulty, Mode);
        }
    }

    public void ClearInput()
    {
        InputField.text = null;
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public void StopGame()
    {
        isPlaying = false;
        Time.timeScale = 0;
        UIController.HideUI();
        UIController.ShowGameOver();
    }

    public void StartGame()
    {
        isPlaying = true;
        Time.timeScale = 1;
        Score = 0;
        UIController.ResetScoreText();
        UIController.HideStartGamePanel();
        UIController.ShowUI();
    }

    public void AddScore(int _value)
    {
        Score += _value;
        if(Score > HighScore)
        {
            HighScore = Score;
            UIController.UpdateHighscoreText(HighScore);
        }
        UIController.UpdateScoreText(Score);
    }

    public void QuitGame()
    {
        SkyboxController.DestroyAllRaindrops();
        Score = 0;
        UIController.UpdateScoreText(Score);
        UIController.HideGameOver();
        UIController.ShowStartGamePanel();
    }

    public void EnterSettings()
    {
        UIController.HideStartGamePanel();
        UIController.ShowSettingsPanel();

    }

    public void SaveSettings()
    {
        Difficulty = DifficultyDropdown.value;
        Mode = ModeDropdown.value;
        UIController.HideSettingsPanel();
        UIController.ShowStartGamePanel();
    }
}
