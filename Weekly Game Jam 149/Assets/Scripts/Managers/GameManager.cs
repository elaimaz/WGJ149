using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }
            return _instance;
        }
    }

    public Recipe recipe;

    public Item firstItem;
    public Item secondItem;

    public Item lastOneLeft = null;

    public float time = 30f;
    public bool timeUp = false;
    public bool timeStop = false;

    public bool canMix = true;
    public bool newTurn = true;

    public List<Item> randomItemList = new List<Item>();

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        ChooseRandomOrder();
    }

    private void Update()
    {
        if (time >= 0 && timeStop == false)
        {
            time -= Time.deltaTime;
        }
        else if(timeStop == false)
        {
            if (timeUp == true)
            {
                UIManager.Instance.TimesUpPanel();
            }
            timeUp = true;
        }
        UIManager.Instance.UpdateTimer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Mix();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            int count = 0;
            foreach (Item it in ItemsList.Instance.Items)
            {
                count++;
                Debug.Log(it.Name);
            }
            Debug.Log(count);
        }
    }

    public void ChooseRandomOrder()
    {
        int recipesCount;
        int randomRecipeNumber;

        recipesCount = ItemsRecipes.Instance.Recipes.Count;
        randomRecipeNumber = Random.Range(0, recipesCount - 1);
        recipe = ItemsRecipes.Instance.Recipes[randomRecipeNumber];

        RevelItems(recipe);

        UIManager.Instance.UpdateOrderPanelText(recipe.Name, recipe.SolidElement.ToString(), recipe.LiquidElement.ToString(), recipe.MagicElement.ToString());
        RandomizeItemList();
        PopulateItems.Instance.PopulateItemsBoard();
    }

    private void RevelItems(Recipe recipe)
    {
        int firstRandom = Random.Range(1, 3);

        if (firstRandom == 1)
        {
            firstItem = SearchPossibleItem(recipe.LiquidElement.ToString());
        }else if (firstRandom == 2)
        {
            firstItem = SearchPossibleItem(recipe.SolidElement.ToString());
        }
        else
        {
            firstItem = SearchPossibleItem(recipe.MagicElement.ToString());
        }

        int secondRandom = Random.Range(1, 3);
        while (firstRandom == secondRandom)
        {
            secondRandom = Random.Range(1, 3);
        }

        if (secondRandom == 1)
        {
            secondItem = SearchPossibleItem(recipe.LiquidElement.ToString());
        }
        else if (secondRandom == 2)
        {
            secondItem = SearchPossibleItem(recipe.SolidElement.ToString());
        }
        else
        {
            secondItem = SearchPossibleItem(recipe.MagicElement.ToString());
        }
    }

    private Item SearchPossibleItem(string type)
    {
        List<Item> possibleItemsList = new List<Item>();
        Item choosenItem;
        foreach (Item item in ItemsList.Instance.Items)
        {
            if (item.ItemType.ToString() == type)
            {
                possibleItemsList.Add(item);
            }
        }
        int randomItemIndex = Random.Range(0, possibleItemsList.Count - 1);
        choosenItem = possibleItemsList[randomItemIndex];
        return choosenItem;
    }

    public void Mix()
    {
        if (lastOneLeft.Name.Length > 0 && canMix == true)
        {
            canMix = false;
            timeStop = true;
            string liquid;
            string solid;
            string magic;
            bool correct = false;

            if (firstItem.ItemType.ToString() == "RedLiquid" || firstItem.ItemType.ToString() == "GreenLiquid" || firstItem.ItemType.ToString() == "BlueLiquid" || firstItem.ItemType.ToString() == "YellowLiquid")
            {
                liquid = firstItem.ItemType.ToString();
            }
            else if (secondItem.ItemType.ToString() == "RedLiquid" || secondItem.ItemType.ToString() == "GreenLiquid" || secondItem.ItemType.ToString() == "BlueLiquid" || secondItem.ItemType.ToString() == "YellowLiquid")
            {
                liquid = secondItem.ItemType.ToString();
            }
            else
            {
                liquid = lastOneLeft.ItemType.ToString();
            }

            if (firstItem.ItemType.ToString() == "RedStone" || firstItem.ItemType.ToString() == "GreenStone" || firstItem.ItemType.ToString() == "BlueStone" || firstItem.ItemType.ToString() == "YellowStone")
            {
                solid = firstItem.ItemType.ToString();
            }
            else if (secondItem.ItemType.ToString() == "RedStone" || secondItem.ItemType.ToString() == "GreenStone" || secondItem.ItemType.ToString() == "BlueStone" || secondItem.ItemType.ToString() == "YellowStone")
            {
                solid = secondItem.ItemType.ToString();
            }
            else
            {
                solid = lastOneLeft.ItemType.ToString();
            }

            if (firstItem.ItemType.ToString() == "RedMagic" || firstItem.ItemType.ToString() == "GreenMagic" || firstItem.ItemType.ToString() == "BlueMagic" || firstItem.ItemType.ToString() == "YellowMagic")
            {
                magic = firstItem.ItemType.ToString();
            }
            else if (secondItem.ItemType.ToString() == "RedMagic" || secondItem.ItemType.ToString() == "GreenMagic" || secondItem.ItemType.ToString() == "BlueMagic" || secondItem.ItemType.ToString() == "YellowMagic")
            {
                magic = secondItem.ItemType.ToString();
            }
            else
            {
                magic = lastOneLeft.ItemType.ToString();
            }

            foreach (Recipe rec in ItemsRecipes.Instance.Recipes)
            {
                if (rec.LiquidElement.ToString() == liquid && rec.SolidElement.ToString() == solid && rec.MagicElement.ToString() == magic)
                {
                    UIManager.Instance.CreatedPotion.GetComponent<Image>().sprite = rec.RecipeSprite;
                    correct = true;
                }
            }
            StartCoroutine(ShowRightWrongPanel(correct));
        }
        else
        {
            Debug.Log("Last one is NULL");
        }
    }

    public void RandomizeItemList()
    {
        randomItemList = ItemsList.Instance.Items;
        for (int i = 0; i < randomItemList.Count; i++)
        {
            Item temp = randomItemList[i];
            int randomIndex = Random.Range(i, randomItemList.Count);
            randomItemList[i] = randomItemList[randomIndex];
            randomItemList[randomIndex] = temp;
        }
    }

    private IEnumerator ShowRightWrongPanel(bool rightWrong)
    {
        yield return new WaitForSeconds(0.5f);
        if (rightWrong == true)
        {
            UIManager.Instance.RightPanel();
        }
        else
        {
            UIManager.Instance.WrongPanel();
        }
    }
}
