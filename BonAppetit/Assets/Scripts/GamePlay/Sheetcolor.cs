using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheetcolor : MonoBehaviour
{
    private SpriteRenderer spRender;
    [Header("ÅÐ¶¨Ïß")]
    public GameObject deadLine;

    void Start()
    {
        spRender = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name =="DeadLine")
        {
            spRender.color = Color.red;
        }
    }
}
