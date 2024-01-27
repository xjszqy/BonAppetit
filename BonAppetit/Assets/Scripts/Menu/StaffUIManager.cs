using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaffUIManager : MonoBehaviour
{
    public Button QuitBtn;
    private void OnEnable()
    {
        QuitBtn.onClick.AddListener(Quit);
    }
    private void OnDisable()
    {
        QuitBtn.onClick.RemoveAllListeners();
    }
    public void Quit()
    {
        SceneLoader.Instance.QuitGame();
    }
}
