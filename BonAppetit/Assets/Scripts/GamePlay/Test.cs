using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Test : MonoBehaviour
{
    public MicroRecord microRecord;
    public float minVolume=20f;
    public float minPosition = -4f;
    public float maxPosition = 4f;
    public float mintPitch = 90f;
    public float maxPitch = 440f;
    public bool shouldReturnToCenter = true;
    public float returnSpeed = 1f;
    public Vector2 centerPoz= Vector2.zero;
    public float targetY;
    // Start is called before the first frame update
    void Start()
    {
        
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
            transform.position = Vector2.Lerp(transform.position, new Vector2(0f, targetY), Time.deltaTime * returnSpeed);
        }
        else
        {
            targetY = minPosition;
            transform.position = Vector2.Lerp(transform.position, new Vector2(0f, targetY), Time.deltaTime * returnSpeed);
        }
    }
}
