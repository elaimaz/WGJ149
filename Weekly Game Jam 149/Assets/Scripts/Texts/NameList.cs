using System.Collections.Generic;
using UnityEngine;

public class NameList : MonoBehaviour
{
    private static NameList _instance;
    public static NameList Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Name List is NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public List<string> Names = new List<string>();


    public string GetRandomName()
    {
        int randomIndex = Random.Range(0, Names.Count - 1);
        return Names[randomIndex];
    }
}
