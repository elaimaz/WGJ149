using System.Collections.Generic;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    private static OrderList _instance;
    public static OrderList Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Order List is NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public List<string> intro = new List<string>();
    public List<string> firstRequest = new List<string>();
    public List<string> secondRequest = new List<string>();

    public void InitializeIntro()
    {
        intro.Clear();
        string text = "Hello potion mixer, my name is " + NameList.Instance.GetRandomName() + " Nice To meet You.";
        intro.Add(text);
        text = "Pitful potion mixer i demand a potion right now.";
        intro.Add(text);
        text = "Hi my friend, your work is needed.";
        intro.Add(text);
    }

    public void PopulateFirstRequest()
    {
        firstRequest.Clear();
        List<string> stats = ItemsRecipes.Instance.NPCPotionStats();
        string text = "For my next quest i will need something that " + stats[0] + ".";
        firstRequest.Add(text);
        text = "I'm in the search of an old tome, many mysteries and dangerous place are ahead of me for that " + stats[0] + " is needed.";
        firstRequest.Add(text);
        text = "The might " + NameList.Instance.GetRandomName() + " is terrifying the lands nearby i need a potion that gives me " + stats[0] + " to face this terrible enemy and bring him to the hammer justice.";
        firstRequest.Add(text);
    }

    public void PopulateSecondRequest()
    {
        secondRequest.Clear();
        List<string> stats = ItemsRecipes.Instance.NPCPotionStats();
        string text = "For that quest i also will need " + stats[1] + ".";
        secondRequest.Add(text);
        text = "Between me and my objective is " + NameList.Instance.GetRandomName() + " a potion that burst my " + stats[1] + " is needed.";
        secondRequest.Add(text);
        text = "Dark cloud are rising in the horizon, hope is just an old tale now, only with more " + stats[1] + " i will complete my quest, and for that your help is extremely necessary.";
        secondRequest.Add(text);
    }

    public string RandomIntro()
    {
        int randomIndex = Random.Range(0, intro.Count - 1);
        return intro[randomIndex];
    }

    public string RandomFirstRequest()
    {
        int randomIndex = Random.Range(0, firstRequest.Count - 1);
        return firstRequest[randomIndex];
    }

    public string RandomSecondRequest()
    {
        int randomIndex = Random.Range(0, secondRequest.Count - 1);
        return secondRequest[randomIndex];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (var tx in intro)
            {
                Debug.Log(tx);
            }
        }
    }
}
