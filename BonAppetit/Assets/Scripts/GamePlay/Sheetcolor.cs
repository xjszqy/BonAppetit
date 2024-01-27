using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheetcolor : MonoBehaviour
{
    private SpriteRenderer spRender;
    [Header("fail��Ч")]
    public ParticleSystem failParticleSystem;
    [Header("Combo��Ч")]
    public ParticleSystem comboParticleSystem;
    private void Start()
    {
        spRender = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name =="DeadLine")
        {
            spRender.color = Color.red;
        }
        if (collision.name == "DestroyLine")
        {
            failParticleSystem.Play();
            failParticleSystem.transform.position = this.transform.position;
            Destroy(gameObject);
        }
    }
}
