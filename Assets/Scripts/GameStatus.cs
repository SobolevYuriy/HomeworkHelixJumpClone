using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public Controls Controls;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public ParticleSystem Confeti;
    public ParticleSystem Smoke;

    public enum Status
    {
        Playing,
        Won,
        Lose,
    }
    public Status CurrentStatus { get; private set; }

    public void OnPlayerDied()
    {
        
        if (CurrentStatus != Status.Playing) return;
        CurrentStatus = Status.Lose;
        Controls.enabled = false;
        LosePanel.SetActive(true);
        Smoke.GetComponent<ParticleSystem>().Play();
    }

    public void OnPlayerReachFinish()
    {
        if (CurrentStatus != Status.Playing) return;
        Controls.enabled = false;
        LevelIndex++;
        WinPanel.SetActive(true);
        Confeti.GetComponent<ParticleSystem>().Play();
    }


    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";
}
