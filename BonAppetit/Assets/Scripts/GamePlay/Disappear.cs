using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("��ʧ����")]
    public Material material;
    [Header("����")]
    public GameObject Yinfu;
    public GameObject DeadLine;
    private void Update()
    {
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "DeadLine")
        {
            //material.SetFloat("_DisappearOffset",);
        }
    }
}
