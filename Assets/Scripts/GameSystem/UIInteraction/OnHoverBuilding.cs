using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverBuilding : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverMenu;

    void Start()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverMenu.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HoverMenu.SetActive(false);
    }
}
