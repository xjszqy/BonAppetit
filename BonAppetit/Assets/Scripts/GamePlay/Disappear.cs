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
    [Header("������Ч")]
    public ParticleSystem comboParticleSystem;
    private Vector2 lerpPoxitionX;
    [Header("�Ƿ���")]
    public bool isPressed;
    [Header("�Ƿ����ж���")]
    Player player;
    public bool isCombo;
    SpriteRenderer sp;
    private void Start()
    {
        player = GetComponent<Player>();
        materialInstance = new Material(material);
        sp = GetComponent<SpriteRenderer>();
        sp.material = materialInstance;
        materialInstance.SetFloat("_DisappearOffset", 2.5f);
    }
    private void Update()
    {
        lerpPoxitionX = DeadPoint.transform.position - DeadLine.transform.position;
        if (player != null)
        {
            isPressed = player.canEliminate();
        }
        Debug.Log(-lerpPoxitionX.x + 2.5f);
        if (isPressed&&isCombo)
        {
            materialInstance.SetFloat("_DisappearOffset", -lerpPoxitionX.x + 2f);
            comboParticleSystem.transform.position = this.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "DeadLine")
        {
            isCombo = true;
            if (isPressed) 
            {
                comboParticleSystem.Play();
            }   
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isPressed&&collision.name=="DeadLine")
        {
            isCombo=false;
            this.gameObject.SetActive(false);
        }
    }
}
