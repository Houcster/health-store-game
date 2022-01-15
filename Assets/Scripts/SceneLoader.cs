using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void RestartGame()
    {
        AudioManager.Instance.PlayButtonSound();
        SceneManager.LoadScene("GameScene");
        Main.movementSpeed = 4.0f;
        Main.itemsSpawnRange = 3;
        Main.scoreValue = 0;
        Main.isGameOver = false;
    }

    public void RestartGameSafety()
    {
        AudioManager.Instance.PlayButtonSound();
        SceneManager.LoadScene("GameScene");
        Main.isGameOver = false;
    }

    public void StartGame()
    {
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlayButtonSound();
        SceneManager.LoadScene("GameScene");
        Main.isGameOver = false;
    }

    public void GameOver()
    {
        if (Main.scoreValue > Main.highScore)
        {
            PlayerPrefs.SetInt("HighScore", Main.scoreValue);
        }
        SceneManager.LoadScene("GameOverScene");      
    }

    public void ToMenu()
    {
        Main.movementSpeed = 4.0f;
        Main.itemsSpawnRange = 3;
        Main.scoreValue = 0;
        Main.isGameOver = false;
        AudioManager.Instance.PlayButtonSound();
        SceneManager.LoadScene("MainMenuScene");
        AudioManager.Instance.PlayMenuMusic();
    }

    public void FromSettingsToMenu()
    {
        AudioManager.Instance.PlayButtonSound();
        AudioManager.Instance.SaveSoundSettings();
        SceneManager.LoadScene("MainMenuScene");
        AudioManager.Instance.PlayMenuMusic();
    }

    public void ToSettings()
    {
        AudioManager.Instance.PlayButtonSound();
        SceneManager.LoadScene("SettingsScene");
    }

    public void ToInfo()
    {
        AudioManager.Instance.PlayButtonSound();
        SceneManager.LoadScene("InfoScene");
    }

    public void ToQuit()
    {
        AudioManager.Instance.PlayButtonSound();
        Application.Quit();
    }
}
