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

    public List<string> NPCPotionStats()
    {
        List<string> stats = new List<string>();
        
        switch (GameManager.Instance.recipe.Name)
        {
            case "Grand Mana Potion":
                stats.Add("mana");
                stats.Add("mana");
                break;
            case "Healing Mana Potion":
                stats.Add("heal");
                stats.Add("grand mana");
                break;
            case "Fast Mana Potion":
                stats.Add("agility");
                stats.Add("grand mana");
                break;
            case "Strong Mana Potion":
                stats.Add("strength");
                stats.Add("grand mana");
                break;
            case "Grand Health Potion":
                stats.Add("heal");
                stats.Add("heal");
                break;
            case "Magic Health Potion":
                stats.Add("mana");
                stats.Add("grand heal");
                break;
            case "Fast Health Potion":
                stats.Add("agility");
                stats.Add("grand heal");
                break;
            case "Strong Health Potion":
                stats.Add("strength");
                stats.Add("grand heal");
                break;
            case "Grand Agility Potion":
                stats.Add("agility");
                stats.Add("agility");
                break;
            case "Healing Agility Potion":
                stats.Add("heal");
                stats.Add("grand agility");
                break;
            case "Magic Agility Potion":
                stats.Add("mana");
                stats.Add("grand agility");
                break;
            case "Strong Agility Potion":
                stats.Add("strength");
                stats.Add("grand agility");
                break;
            case "Grand Strength Potion":
                stats.Add("strength");
                stats.Add("strength");
                break;
            case "Healing Strength Potion":
                stats.Add("heal");
                stats.Add("grand strength");
                break;
            case "Magic Strength Potion":
                stats.Add("mana");
                stats.Add("grand strength");
                break;
            default:
                stats.Add("agility");
                stats.Add("grand strength");
                break;
        }
        return stats;
    }
}
