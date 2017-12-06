using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TDD_ReignsUI : MonoBehaviour {

    public ReignsUI _reignsUI;
    public float _timeBetweenRefresh = 1;

    public string[] _name = new string[] { "Eloi", "Odile", "Lionel", "Milo" };
    public string[] _randomLeft = new string[] { "Humm Ok...", "Yes !", "Why not.", "C'est pas faux" };
    public string[] _randomRight = new string[] { "Go to hell !!", "No !", "I don't like that", "No reason to do that" };

    [SerializeField]
    public AvatarAndQuestions[] _avatarAndQuestions = new AvatarAndQuestions[] {};

    
    [System.Serializable]
    public struct AvatarAndQuestions {
        public string _name;
        public string []_dialogue;
        public Sprite _avatar;
        public Sprite _background;
       

    }

    private void Start()
    {
        InvokeRepeating("GeneratePlosableData", 0, _timeBetweenRefresh);
    }


   public   void GeneratePlosableData () {
        _reignsUI.SetKingName(Random<string>(_name));
        _reignsUI.SetScoreTo(RandomIndex( 2000));
        _reignsUI.SetYearOfReigns(UnityEngine.Random.Range(0, 200));

        for (int i = 0; i < UnityEngine.Random.Range(0, 3); i++)
        { _reignsUI.SetObjectiveStatus(RandomIndex(6), RandomPourcentage()); }

        AvatarAndQuestions avatar = Random<AvatarAndQuestions>(_avatarAndQuestions);
        Debug.Log("Avatar:" + avatar._name);
        _reignsUI.SetAvatarImage (avatar._avatar);
        _reignsUI.SetImageName(avatar._name);
        _reignsUI.SetDialogue(Random(avatar._dialogue));
        _reignsUI.SetContextBackground(avatar._background);

        _reignsUI.SetLeftAnswer(Random(_randomLeft));
        _reignsUI.SetRightAnswer(Random(_randomRight));

        for (int i = 0; i < UnityEngine.Random.Range(0, 3); i++)
        { _reignsUI.SetBonusStatus(RandomIndex(6), RandomPourcentage()<0.5f); }

    }

    public T Random<T>(params T[] proposition) { return proposition[UnityEngine.Random.Range(0, proposition.Length - 1)]; }
    public int RandomIndex(int max) { return UnityEngine.Random.Range(0, max); }
    public float RandomPourcentage (){ return UnityEngine.Random.Range(0f,1f); }
}
