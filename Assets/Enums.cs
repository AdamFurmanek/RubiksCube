using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    public enum MoveDirection
    {
        R,
        Rp,
        L,
        Lp,
        F,
        Fp,
        B,
        Bp,
        D,
        Dp,
        U,
        Up,
        None
    }

    public enum WallPosition
    {
        Top,
        Bottom,
        Front,
        Back,
        Left,
        Right,
        None
    }

    public enum WallColor
    {
        Red,
        Orange,
        White,
        Yellow,
        Blue,
        Green,
        None
    }
}
