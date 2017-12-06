using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ReignsUserInterface {

    void SetKingName(string kingName);
    void SetScoreTo(int score);
    void SetYearOfReigns(int years);

    void SetDialogue(string dialogue);
    void SetAvatarName(string dialogue);
    void SetImageName(string imageIdName);
    void SetAvatarImage(Sprite texture);


    void SetBonusStatus(int index, bool isComplete);
    void SetBonusStatus(string questId, bool isComplete);
    void SetBonusIcon(int index, Sprite iconTexture);
    void SetBonusIcon(string questId, Sprite iconTexture);

    void SetObjectiveStatus(int index, float pourcentageStatus);
    void SetObjectiveStatus(string objectiveId, float pourcentageStatus);

    void SetLeftAnswer(string text);
    void SetRightAnswer(string text);

    void SetContextBackground(string idToLoad);
    void SetContextBackground(Sprite texture);

    
    ///JUICY
    void HighlighStatusPossiblity(int index, float pourcentageStatus, float nextPourcentStatus);
    void HighlighStatusPossiblity(string objectiveName, float pourcentageStatus, float nextPourcentStatus);

    

}
/// <summary>
/// Facade Abstraite de l'interface du jeu Reigns
/// </summary>
public abstract class ReignsUI : MonoBehaviour, ReignsUserInterface {

    private static ReignsUI _instanceInScene;

    public static ReignsUI InstanceInScene
    {
        get { return _instanceInScene; }
        protected set { _instanceInScene = value; }
    }
    public static ReignsUI I
    {
        get { return _instanceInScene; }
        protected set { _instanceInScene = value; }
    }

    protected void Awake()
    {
        _instanceInScene = this;
    }

    public abstract void SetKingName(string kingName);
    public abstract void SetScoreTo(int score);
    public abstract void SetYearOfReigns(int years);
    public abstract void SetDialogue(string dialogue);
    public abstract void SetImageName(string imageIdName);
    public abstract void SetAvatarImage(Sprite texture);
    public abstract void SetBonusStatus(int index, bool isComplete);
    public abstract void SetBonusStatus(string questId, bool isComplete);
    public abstract void SetBonusIcon(int index, Sprite iconTexture);
    public abstract void SetBonusIcon(string questId, Sprite iconTexture);
    public abstract void SetObjectiveStatus(int index, float pourcentageStatus);
    public abstract void SetObjectiveStatus(string objectiveId, float pourcentageStatus);
    public abstract void SetLeftAnswer(string text);
    public abstract void SetRightAnswer(string text);
    public abstract void SetContextBackground(string idToLoad);
    public abstract void SetContextBackground(Sprite texture);
    public abstract void HighlighStatusPossiblity(int index, float pourcentageStatus, float nextPourcentStatus);
    public abstract void HighlighStatusPossiblity(string objectiveName, float pourcentageStatus, float nextPourcentStatus);
    public abstract void SetAvatarName(string dialogue);
}


    