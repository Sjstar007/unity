using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// Make sure this script is attached on one of the UI object
/// </summary>
public class cardSwaper : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        //  if (CardManager.instance.SelectedCard != null)
        // {
        //     CardManager.instance.MoveSelectedCard(eventData.position);
        // }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
