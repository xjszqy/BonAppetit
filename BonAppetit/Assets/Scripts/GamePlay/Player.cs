using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public MicroRecord microRecord;
    public float minVolume=10f;
    public float canElimateVolume = 20f;
    public float minPosition = -3.5f;
    public float maxPosition = 4f;
    public float mintPitch = 90f;
    public float maxPitch = 440f;
    public bool shouldReturnToCenter = true;
    public bool eatLock = false;
    public float returnSpeed = 1f;
    public Vector2 centerPoz= Vector2.zero;
    public float targetY;
    public float time = 5f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public float Conversion(float pitch)
    {
        return (maxPosition - minPosition) / (maxPitch - mintPitch) * pitch + minPosition;
    }
    // Update is called once per frame
    void Update()
    {                        
        if (microRecord != null && microRecord.volume > minVolume)
        {
            targetY = Conversion(microRecord.pitch);
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, targetY), Time.deltaTime * returnSpeed);
            animator.SetBool("isMove", true);
        }
        else
        {
            targetY = minPosition;
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, targetY), Time.deltaTime * returnSpeed);
            animator.SetBool("isMove", true);
        }
        if(Mathf.Abs(transform.position.y-minPosition)<0.05)
        {
            animator.SetBool("isMove", false);
        }

        
    }
    public bool canEliminate()
    {
        return (microRecord.volume > canElimateVolume);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Yinfu")
        {
            if (canEliminate())
            {
                animator.SetBool("isEat", true);
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Yinfu")
        {
            if (canEliminate())
            {
                animator.SetBool("isEat", false);
            }
        }
    }
}
