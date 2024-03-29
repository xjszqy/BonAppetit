using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUIManager : Singleton<GamePlayUIManager>
{
    public GameObject pausePanel;
    public GameObject settlePanel;
    public Button restartBtn;
    public Button backToMenuBtn;
    public Button staffBtn;
    public Text comboText;
    public int comboNumer=0;
    private void OnEnable()
    {
        restartBtn.onClick.AddListener(ReStart);
        backToMenuBtn.onClick.AddListener(BackToMenu);
        staffBtn.onClick.AddListener(Staff);
        comboNumer = 0;
    }


    private void OnDisable()
    {
        restartBtn.onClick.RemoveAllListeners();
        backToMenuBtn.onClick.RemoveAllListeners();
        staffBtn.onClick.RemoveAllListeners();
    }
    private void Update()
    {
        comboText.text = comboNumer.ToString()+" COMBO";
    }
    public void OpenSettlePanel()
    {
        settlePanel.SetActive(true);
    }
    public void CloseSettlePanel()
    {
        Time.timeScale = 1f;
        settlePanel.SetActive(false);
    }
    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
    }
    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
    }
    private void Staff()
    {
        SceneLoader.Instance.LoadStaffWithCoroutine(); 
    }

    private void BackToMenu()
    {
        SceneLoader.Instance.LoadMenuSceneWithCoroutine();
    }

    private void ReStart()
    {
        SceneLoader.Instance.LoadGameSceneWithCoroutine();
    }
}
