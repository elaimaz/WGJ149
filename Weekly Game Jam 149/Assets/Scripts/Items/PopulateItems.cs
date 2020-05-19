using UnityEngine;
using UnityEngine.UI;

public class PopulateItems : MonoBehaviour
{
    private static PopulateItems _instance;
    public static PopulateItems Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("PopulateItems is NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void PopulateItemsBoard()
    {
        int count = 0;
        while (count < transform.childCount)
        {
            Item item = GameManager.Instance.randomItemList[count];
            transform.GetChild(count).GetComponentInChildren<DragAndDropItens>().item = item;
            transform.GetChild(count).GetChild(0).GetComponent<Image>().sprite = item.ItemSprite;
            count++;
        }
    }
}
