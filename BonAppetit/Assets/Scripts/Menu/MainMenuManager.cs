using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button guidanceBtn;
    public Button quitBtn;
    public Button staffBtn;
    private void OnEnable()
    {
        guidanceBtn.onClick.AddListener(Guidance);
        quitBtn.onClick.AddListener(Quit);
        staffBtn.onClick.AddListener(Staff);
    }

    private void Staff()
    {
        SceneLoader.Instance.LoadStaffWithCoroutine();
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void Guidance()
    {
        SceneLoader.Instance.LoadGuidanceWithCoroutine();
    }

    private void OnDisable()
    {
        guidanceBtn.onClick.RemoveAllListeners();
        quitBtn.onClick.RemoveAllListeners();
        staffBtn.onClick.RemoveAllListeners();
    }
}
