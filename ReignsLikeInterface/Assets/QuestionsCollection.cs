using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class QuestionsCollection
{

    public List<Question> _questions;

}



[System.Serializable]
public class Question
{
    [Tooltip("Id")]
    public string _id;
    [Tooltip("Question Asked")]
    public string _question;
    public Anwser _yes;
    public Anwser _no;

}


[System.Serializable]
public class Anwser
{
    public string _text;
    public Effect [] _effect;

}

[System.Serializable]
public class Effect
{
    public string _idName;
    public float _value;
}

