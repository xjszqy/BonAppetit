using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("消失材质")]
    public Material material;
    public Material materialInstance;
    [Header("音符")]
    public GameObject DeadPoint;
    public GameObject DeadLine;
    [Header("粒子特效")]
    public ParticleSystem comboParticleSystem;
    private Vector2 lerpPoxitionX;
    [Header("是否点击")]
    public bool isPressed;
    [Header("是否处于判定线")]
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
