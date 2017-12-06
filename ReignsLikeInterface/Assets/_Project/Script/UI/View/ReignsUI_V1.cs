using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This version one of the Reign adaptater of the UI is a quick and dirty version
/// It allow the Facade ReignsUi to interact with the UI without knowing what is behind.
/// A version two must be implemented where class are called to manage the UI
/// </summary>
public class ReignsUI_V1 : ReignsUI
{
    public Text _kingName;
    public Text _years;
    public Text _score;
    public Text _avatarName;
    public Image _avatarImage;
    public Text _avatarDialogue;
    public Text _answerLeft;
    public Text _answerRight;

    public Sprite _defaultBackground;
    public Image _backgroundImage;

    public Image[] _objectiveState;
    public Image[] _bonusIcons;

    [Header("Resources")]
    [SerializeField]
    public AvailableSprite [] _spriteAvailable;
    [System.Serializable]
    public class AvailableSprite {
         public string _id;
        public Sprite _sprite;

        }


    public Sprite GetSpriteFor(string idWanted) {
        
        for (int i = 0; i < _spriteAvailable.Length; i++)
        {
            if( _spriteAvailable[i]._id == idWanted)
                return _spriteAvailable[i]._sprite;
        }

        return null;
    }

    public override void HighlighStatusPossiblity(string objectiveName, float pourcentageStatus, float nextPourcentStatus)
    {}

    public override void HighlighStatusPossiblity(int index, float pourcentageStatus, float nextPourcentStatus)
    {}

    public override void SetBonusIcon(string questId, Sprite iconTexture)
    {}

    public override void SetBonusIcon(int index, Sprite iconTexture)
    {
        if (index < 0)
        {
            Debug.LogWarning("[ReignUI_V1:Objectif] Objectif should not be under zero", this.gameObject);
            return;
        }
        if (index >= _bonusIcons.Length)
        {
            Debug.LogWarning("[ReignUI_V1:Objectif] The objective at index " + index + " do not existe", this.gameObject);
            return;
        }
        _bonusIcons[index].sprite = iconTexture;
    }

    public override void SetBonusStatus(string questId, bool isComplete)
    {}

    public override void SetBonusStatus(int index, bool isComplete)
    {
        if (index < 0)
        {
            Debug.LogWarning("[ReignUI_V1:Objectif] Objectif should not be under zero", this.gameObject);
            return;
        }
        if (index >= _bonusIcons.Length)
        {
            Debug.LogWarning("[ReignUI_V1:Objectif] The objective at index " + index + " do not existe", this.gameObject);
            return;
        }
        _bonusIcons[index].gameObject.SetActive(isComplete);
    }

    public override void SetContextBackground(Sprite texture)
    {
        _backgroundImage.sprite = texture==null?_defaultBackground:texture;
    }

    public override void SetContextBackground(string idToLoad)
    {

        SetContextBackground(GetSpriteFor(idToLoad));
    }

    public override void SetDialogue(string dialogue)
    {
        _avatarDialogue.text = dialogue;
    }

    public override void SetAvatarImage(Sprite texture)
    {
        _avatarImage.sprite = texture;
    }

    public override void SetImageName(string imageIdName)
    {

        _avatarName .text= imageIdName;
    }

    public override void SetKingName(string kingName)
    {
        if (_kingName != null)
            _kingName.text = "" + kingName;
    }

    public override void SetLeftAnswer(string text)
    {
        if (_answerLeft != null)
            _answerLeft.text = "" + text;
    }

    public override void SetObjectiveStatus(string objectiveId, float pourcentageStatus)
    {}

    public override void SetObjectiveStatus(int index, float pourcentageStatus)
    {
        if (index < 0) {
            Debug.LogWarning("[ReignUI_V1:Objectif] Objectif should not be under zero", this.gameObject);
            return;
        }
        if (index >= _objectiveState.Length)
        {
            Debug.LogWarning("[ReignUI_V1:Objectif] The objective at index " + index + " do not existe", this.gameObject);
            return;
        }
        pourcentageStatus = Mathf.Clamp(pourcentageStatus, 0f, 1f);
        _objectiveState[index].fillAmount = pourcentageStatus;
    }


    public override void SetRightAnswer(string text)
    {
        if (_answerRight != null)
            _answerRight.text = "" + text;
    }

    public override void SetScoreTo(int score)
    {
        if(_score!=null)
        _score.text = "" + score;
    }

    public override void SetYearOfReigns(int years)
    {
        if (_years != null)
            _years.text = ""+years;
    }

    public override void SetAvatarName(string name)
    {
        _avatarName.text = name;
    }
}
