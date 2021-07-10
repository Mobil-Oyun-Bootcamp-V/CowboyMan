using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagement : MonoBehaviour
{
    public event System.Action OnRestartLevel;

    [SerializeField] GameObject GameOverObject;
    [SerializeField] GameObject WinObject;
    [SerializeField] Text WinPointText;
    [SerializeField] Text WinTimeText;
    [SerializeField] Text LosePointText;
    [SerializeField] Text LoseTimeText;

    CalculatePoint _calculatePoint;
    PlayerController _playerController;
    EnvironmentObjects _environmentObjects;
    Bag _bag;
    void Awake()
    {
        _calculatePoint = GetComponent<CalculatePoint>();
        _playerController = GameObject.FindObjectOfType<PlayerController>();
        _environmentObjects = GameObject.FindObjectOfType<EnvironmentObjects>();
        _bag = GameObject.FindObjectOfType<Bag>();
    }
    void OnEnable()
    {
        GameManager.Instance.OnIsWin += WinPanel;
        GameManager.Instance.OnIsDead += GameOverPanel;

        OnRestartLevel += PlayerManager.Instance.ResetAllStates;
        OnRestartLevel += _playerController.ResetPlayer;
        OnRestartLevel += _environmentObjects.ResetEnvironment;
        OnRestartLevel += _calculatePoint.ResetScore;
        OnRestartLevel += _calculatePoint.ResetTime;
        OnRestartLevel += _bag.ResetBagStack;

    }
    void OnDisable()
    {
        GameManager.Instance.OnIsWin -= WinPanel;
        GameManager.Instance.OnIsDead -= GameOverPanel;

        OnRestartLevel -= PlayerManager.Instance.ResetAllStates;
        OnRestartLevel -= _playerController.ResetPlayer;
        OnRestartLevel -= _environmentObjects.ResetEnvironment;
        OnRestartLevel -= _calculatePoint.ResetScore;
        OnRestartLevel -= _calculatePoint.ResetTime;
        OnRestartLevel -= _bag.ResetBagStack;
    }
    void GameOverPanel()
    {
        GameOverObject.SetActive(true);
        LosePointText.text = _calculatePoint.GetPoint().ToString();
        LoseTimeText.text = _calculatePoint.GetTime().ToString();
    }
    void WinPanel()
    {
        WinObject.SetActive(true);
        WinPointText.text = _calculatePoint.GetPoint().ToString();
        WinTimeText.text = _calculatePoint.GetTime().ToString();
    }
    public void RestartLevel()
    {
        GameOverObject.SetActive(false);
        OnRestartLevel?.Invoke();
    }
    public void NextLevel()
    {
        OnRestartLevel?.Invoke();
        LoadLevelScene();
    }
    public void LoadLevelScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-1)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
