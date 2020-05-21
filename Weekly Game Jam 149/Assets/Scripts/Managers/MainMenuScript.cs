using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject HowToPlayPanel;
    public Text text;
    public Text buttonText;
    private bool next = false;
    public void StartGame()
    {
        SceneManager.LoadScene(1);   
    }

    public void EnableHowToPlay()
    {
        MainMenuPanel.SetActive(false);
        HowToPlayPanel.SetActive(true);
    }

    public void EnableMainMenu()
    {
        MainMenuPanel.SetActive(true);
        HowToPlayPanel.SetActive(false);
    }

    public void NextText()
    {
        buttonText.text = "Back";
        text.text = "Example:\nYou receive an order to make a potion that gives a grand health to the player and agility, for that you will need:\n2 Red Ingredients\n1 Green ingredient\n\nAn order asking just for mana, then you will need:\n3 Blue Itens\n\nNone of the recipes requires mixing 3 colors. Always will be:\n3 ingredients of the same color\nor\n2 ingredients of the same color + one ingredient of different color\n\nClick on the item to Add it in the Mix and read it's description. THen click on the MIX button to finish your potion.\n\nControls:\nSpace = MIX\nESCAPE = Quit Game";
    }

    public void BackText()
    {
        buttonText.text = "Next";
        text.text = "This game Consist in mixing 3 different ingredients to make a potion required for the NPC in the right time. There are 3 Types of ingredients that is needed to make a potion, they are:\nRock Ingredient\nLiquid Ingredient\nMagic Ingredient\n\nEach request for potion wil ask 1 or 2 stats that needs to be in the potion, the stats are:\nHealth\nMana\nAgility\nStrength\n\nEach ingredient have a stat attached to it. Also, every stat has a color that can help you connect the ingredient to the right stat.\nRed = Health\nBlue = Mana\nGreen = Agility\nYellow = strength";
    }

    public void NextOrBack()
    {
        if (next == false)
        {
            next = true;
            NextText();
        }
        else
        {
            next = false;
            BackText();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
