using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidanceUIManager : MonoBehaviour
{
    public Button GamePlayBtn;
    private void OnEnable()
    {
        GamePlayBtn.onClick.AddListener(StartGamePlay);
    }
    private void OnDisable()
    {
        GamePlayBtn.onClick.RemoveAllListeners();
    }
    public void StartGamePlay()
    {
        SceneLoader.Instance.LoadGameSceneWithCoroutine();
    }
}
