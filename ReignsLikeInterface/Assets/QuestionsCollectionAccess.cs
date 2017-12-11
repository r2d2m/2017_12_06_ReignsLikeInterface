using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QuestionsCollectionAccess : MonoBehaviour
{
    public QuestionsCollection _reignsCollection;

    public string _path;


    // Use this for initialization
    void Start()
    {
        
        string text = File.ReadAllText(_path);
        if (string.IsNullOrEmpty(text)) return;

        if (!File.Exists(_path))
            File.Create(_path);


        _reignsCollection =  JsonUtility.FromJson<QuestionsCollection>(text);

        Debug.Log("Questions imp:" + text);

    }
    private void OnDestroy()
    {
        string text = JsonUtility.ToJson(_reignsCollection);

        if (string.IsNullOrEmpty(text)) return;

        if (!File.Exists(_path))
            File.Create(_path);

        File.WriteAllText(_path, text);
        Debug.Log("Questions ext:" +text);

    }
    void Reset() {
        _path = Application.dataPath;
    }
}
