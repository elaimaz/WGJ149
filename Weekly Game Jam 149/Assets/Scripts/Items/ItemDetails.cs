using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDetails : MonoBehaviour, IPointerDownHandler
{
    private enum HolderType { RevealedItem1, RevealedItem2 }
    [SerializeField]
    private HolderType type;
    public Item item;

    private void Update()
    {
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        if (type == HolderType.RevealedItem1)
        {
            item = GameManager.Instance.firstItem;
        }
        else
        {
            item = GameManager.Instance.secondItem;
        }
        GetComponent<Image>().sprite = item.ItemSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UIManager.Instance.UpdateDescriptionPanelText(item.Description, item.Name, item.ItemType.ToString());
    }
}
