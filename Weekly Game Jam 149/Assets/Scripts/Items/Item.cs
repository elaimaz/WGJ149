using UnityEngine;

[System.Serializable]
public class Item
{
    public string Name;
    public enum Type { RedLiquid, GreenLiquid, BlueLiquid, YellowLiquid, RedStone, GreenStone, BlueStone, YellowStone, RedMagic, GreenMagic, BlueMagic, YellowMagic }
    public Type ItemType;
    public string Description;
    public Sprite ItemSprite;
}
