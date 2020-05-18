using UnityEngine;

public class TestRecipes : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var item in ItemsList.Instance.Items)
            {
                Debug.Log(item.ItemType);
            }
        }       
    }
}
