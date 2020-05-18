using UnityEngine;
using UnityEngine.UI;

public class PopulateItems : MonoBehaviour
{
    private void Update()
    {
        PopulateItemsBoard();
    }

    private void PopulateItemsBoard()
    {
        int count = 0;
        while (count < transform.childCount)
        {
            Item item = ItemsList.Instance.Items[count];
            transform.GetChild(count).GetComponentInChildren<DragAndDropItens>().item = item;
            transform.GetChild(count).GetComponentInChildren<Image>().sprite = item.ItemSprite;
            count++;
        }
    }
}
