using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StoryInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class StoryData
{

    public class Avatar
    {
        public string _id;
        public string _name;
    }


}


public class QuestionByAvatar
{

    public Avatar _avatar;
    public QuestionsCollection _questions;

}
