using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colors 
{
    Red,
    Blue,
    Yellow,
    Green,
    Magenta,
    Cyan,
    Default
}
public static class ColorGetter
{
    public static Color GetColor(Colors col)
    {
        switch (col)
        {
            case Colors.Red:
                return Color.red;

            case Colors.Blue:
                return Color.blue;

            case Colors.Yellow:
                return Color.yellow;

            case Colors.Green:
                return Color.green;

            case Colors.Magenta:
                return Color.magenta;

            case Colors.Cyan:
                return Color.cyan;

            default:
                return Color.white;
        }
    }
}