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
        U,
        Up,
        D,
        Dp,
        RL,
        RLp,
        FB,
        FBp,
        UD,
        UDp,
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

    public enum WallType
    {
        F1,
        F2,
        F3,
        U1,
        U2,
        U3,
        R1,
        R2,
        R3,
        None
    }
}
