using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("��ʧ����")]
    public Material material;
    Material materialInstance;
    [Header("����")]
    public GameObject DeadPoint;
    public GameObject DeadLine;
    [Header("������Ч")]
    public ParticleSystem comboParticleSystem;
    private Vector2 lerpPoxitionX;
    [Header("�Ƿ���")]
    public bool isPressed;
    [Header("�Ƿ����ж���")]
    public bool isCombo;
    SpriteRenderer sp;
    public Player otherScript;
    private void Start()
    {
        GameObject otherGameObject = GameObject.Find("Q_character_1");
        materialInstance = new Material(material);
        sp = GetComponent<SpriteRenderer>();
        sp.material = materialInstance;
        materialInstance.SetFloat("_DisappearOffset", 2.5f);
    }
    private void Update()
    {
        lerpPoxitionX = DeadPoint.transform.position - DeadLine.transform.position;
        //if (otherScript.isEating && isCombo)
        //{
        //    materialInstance.SetFloat("_DisappearOffset", (-lerpPoxitionX.x) * 2 - 5);
        //    comboParticleSystem.transform.position = this.transform.position;
        //    Debug.Log(this.transform.position + comboParticleSystem.transform.position);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "DeadLine")
        {
            isCombo = true;
            if (isPressed)
            {
                Debug.Log("Enter");
                materialInstance.SetFloat("_DisappearOffset", (-lerpPoxitionX.x) * 2 - 5);
                comboParticleSystem.transform.position = this.transform.position;
                comboParticleSystem.Play();
                Destroy(gameObject);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isPressed && collision.name == "DeadLine")
        {
            isCombo = false;
            Destroy(this.gameObject);
        }
    }
}
