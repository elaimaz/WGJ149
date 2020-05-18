using System.Collections.Generic;
using UnityEngine;

public class ItemsRecipes : MonoBehaviour
{
    private static ItemsRecipes _instance;
    public static ItemsRecipes Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Items Recipes is NULL");
            }
            return _instance;
        }
    }

    public List<Recipe> Recipes = new List<Recipe>();

    private void Awake()
    {
        _instance = this;
    }
}
