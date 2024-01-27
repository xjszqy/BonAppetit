using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlay : MonoBehaviour
{
    [Header("开始页面")]
    public GameObject gameBegin;
    public bool isStart;
    [Header("结束页面")]
    public GameObject gameEnd;
    [Header("倒计时")]
    public float endTime;
    private float currentTime;
    [Header("乐谱")]
    public GameObject sheetMusic;
    [Header("速度")]
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = endTime;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart)
        {
            if (Input.anyKeyDown)
            {
                isStart = true;
                gameBegin.SetActive(false);
            }
        }
        else
        {
            if (Time.timeScale != 0)
            {
                CountDown();
            }
        }
    }

    void FixedUpdate()
    {
        if (isStart)
        {
            SheetMusicMove();
        }
    }
    private void CountDown()
    {
        if (currentTime >= 0f)
        {
            currentTime = currentTime - Time.deltaTime;
        }
        else
        {
            gameEnd.SetActive(true);
        }
    }

    private void SheetMusicMove()
    {
        rb.velocity = new Vector2(speed, 0);
    }


    public void SwitchToDynamicUpdateMode()
    {
        InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
    }
    public void SwitchToFixedUpdateMode()
    {
        InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
    }


}
