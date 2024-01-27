using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bell : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject tips;
    public void OnPointerEnter(PointerEventData eventData)
    {
        tips.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tips.SetActive(false);
    }


}

