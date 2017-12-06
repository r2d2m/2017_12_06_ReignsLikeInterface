using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderPlus : Slider {

    public UnityEvent _onEnter;
    public UnityEvent _onExit;

    public bool _debug;
    public override void OnPointerUp(PointerEventData eventData)
    {
        if(_debug)
        Debug.Log("The cursor exited the selectable UI element.");
        _onExit.Invoke();
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if(_debug)
        Debug.Log("The cursor start the selectable UI element.");
        _onEnter.Invoke();
    }
}
