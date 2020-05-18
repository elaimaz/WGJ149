using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropItens : MonoBehaviour, IPointerDownHandler
{
    public Item item;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item != null)
        {
            GameManager.Instance.lastOneLeft = item;
            UIManager.Instance.UpdateDescriptionPanelText(item.Description, item.Name, item.ItemType.ToString());
            UIManager.Instance.UpdateLastOneImage(item.ItemSprite);
        }
    }
}
