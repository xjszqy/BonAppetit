using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [Header("开始页面")]
    public GameObject gameBegin;
    public bool isStart;
    [Header("倒计时")]
    public float endTime;
    private float currrentTime;
    [Header("乐谱")]
    public GameObject sheetMusic;
    [Header("速度")]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

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
            SheetMusicMove();
            CountDown();
        }
    }

    private void CountDown()
    {
        currrentTime = endTime-Time.deltaTime;
    }

    private void SheetMusicMove()
    {
        sheetMusic.transform.Translate(Vector3.right * speed);
    }
}
