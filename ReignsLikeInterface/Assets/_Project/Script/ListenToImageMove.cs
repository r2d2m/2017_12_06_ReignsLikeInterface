using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ListenToImageMove : MonoBehaviour {

    public SliderPlus _slider;

    [Range(0f,0.5f)]
    public float _toActivateRespond = 0.4f;

    [Range(0f, 0.5f)]
    public float _toDisplayRespond = 0.1f;

    [System.Serializable]
    public class InTheZoneEvent : UnityEvent<bool>{

    }

    public UnityEvent _onLeftAsked;
    public UnityEvent _onRightAsked;


    //DIRTY
    public Transform _imageRoot;
    public Transform _leftBorder;
    public Transform _rightBorder;
    public GameObject _leftAnswer;
    public GameObject _rightAnswer;
    public GameObject _backgroundAnswer;


    private bool _leftActivate;
    private bool _rightActivate;


    void Start () {
        _slider.onValueChanged.AddListener(SliderChanged);
        _slider._onExit.AddListener(ResetValueToCenter);
	}

    private void ResetValueToCenter()
    {
        _slider.value=0.5f;
        _leftActivate = false;
        _rightActivate = false;
        _backgroundAnswer.SetActive(false);

    }

    private void SliderChanged(float value)
    {

        float pourcentUsedByImage= _leftActivate || _rightActivate?  0.5f: value;
        Vector3 direction = _rightBorder.position - _leftBorder.position;
        _imageRoot.position = _leftBorder.position + direction * pourcentUsedByImage;


        bool isDisplaingLeft = value < (0.5f - _toDisplayRespond);
        _leftAnswer.SetActive(isDisplaingLeft && (!_leftActivate && !_rightActivate));
        bool isDisplaingRight = value > (0.5f + _toDisplayRespond);
        _rightAnswer.SetActive(isDisplaingRight && (!_leftActivate && !_rightActivate));
        _backgroundAnswer.SetActive( (isDisplaingLeft || isDisplaingRight) && (!_leftActivate && !_rightActivate));

        if (!_leftActivate && value < (0.5f - _toActivateRespond))
        {
            _leftActivate = true;
            _onLeftAsked.Invoke();
        }
        if (!_rightActivate && value > (0.5f + _toActivateRespond))
        {
            _rightActivate = true;
            _onRightAsked.Invoke();
            _backgroundAnswer.SetActive(true);
        }

    }
}
