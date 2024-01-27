using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("ÏûÊ§²ÄÖÊ")]
    public Material material;
    [Header("Òô·û")]
    public GameObject Yinfu;
    public GameObject DeadLine;
    private Vector2 lerpPoxitionX;

    private void Start()
    {
        material.SetFloat("_DisappearOffset", 2.5f);

    }
    private void Update()
    {
        lerpPoxitionX = Yinfu.transform.position - DeadLine.transform.position;
        Debug.Log(-lerpPoxitionX.x + 2.5f);
        material.SetFloat("_DisappearOffset", -lerpPoxitionX.x + 2.5f);

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.name == "DeadLine")
    //    {
    //        material.SetFloat("_DisappearOffset", -lerpPoxitionX.x+2.5f);
    //    }
    //}
}
