using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlay : MonoBehaviour
{
    [Header("��ʼҳ��")]
    public GameObject gameBegin;
    public bool isStart;
    [Header("����ҳ��")]
    public GameObject gameEnd;
    [Header("����ʱ")]
    public float endTime;
    private float currentTime;
    [Header("����")]
    public GameObject sheetMusic;
    [Header("�ٶ�")]
    public float speed;
    Rigidbody2D rb;

    public bool isPlaying;//�Ƿ���ͣ
    // Start is called before the first frame update
    void Start()
    {
        currentTime = endTime;
        isPlaying = true;
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
            if(isPlaying)
            {
                CountDown();
                Stop();
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

    public void Stop()
    {
        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPlaying = false;
                SwitchToDynamicUpdateMode();
                Time.timeScale = 0;
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPlaying = true;
                SwitchToFixedUpdateMode();
                Time.timeScale = 1;
            }
        }
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
