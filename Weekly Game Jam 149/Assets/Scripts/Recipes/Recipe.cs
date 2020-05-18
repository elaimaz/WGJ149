using UnityEngine;

[System.Serializable]
public class Recipe
{
    public int Id;
    public string Name;
    public enum Liquid { RedLiquid, GreenLiquid, BlueLiquid, YellowLiquid}
    public enum Solid { RedStone, GreenStone, BlueStone, YellowStone }
    public enum Magic { RedMagic, GreenMagic, BlueMagic, YellowMagic }
    public Liquid LiquidElement;
    public Solid SolidElement;
    public Magic MagicElement;
    public Sprite RecipeSprite;
}
