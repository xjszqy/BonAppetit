using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("��ʧ����")]
    public Material material;
    public Material materialInstance;
    [Header("����")]
    public GameObject DeadPoint;
    public GameObject DeadLine;
    private Vector2 lerpPoxitionX;
    SpriteRenderer sp;
    private void Start()
    {
        
        materialInstance = new Material(material);

        materialInstance.SetFloat("_DisappearOffset", 2.5f);
    }
    private void Update()
    {
        lerpPoxitionX = DeadPoint.transform.position - DeadLine.transform.position;
        Debug.Log(-lerpPoxitionX.x + 2.5f);
        materialInstance.SetFloat("_DisappearOffset", -lerpPoxitionX.x + 2.5f);

    }
}
