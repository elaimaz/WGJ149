using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    private static ItemsList _instance;
    public static ItemsList Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("ItemsList is NULL");
            }
            return _instance;
        }
    }

    public List<Item> Items = new List<Item>();

    private void Awake()
    {
        _instance = this;
    }
}
