using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class Cubie : MonoBehaviour
{
    WallColor top;
    WallColor bottom;
    WallColor front;
    WallColor back;
    WallColor left;
    WallColor right;
    WallColor[] walls;

    int wallF;
    int wallR;
    int wallU;

    private void Awake()
    {
        top = transform.Find("White") ? WallColor.White : WallColor.None;
        bottom = transform.Find("Yellow") ? WallColor.Yellow : WallColor.None;
        front = transform.Find("Red") ? WallColor.Red : WallColor.None;
        back = transform.Find("Orange") ? WallColor.Orange : WallColor.None;
        left = transform.Find("Green") ? WallColor.Green : WallColor.None;
        right = transform.Find("Blue") ? WallColor.Blue : WallColor.None;
        walls = new WallColor[] { top, bottom, front, back, left, right };

        wallF = 2;
        if()
    }

    public WallColor GetColor(WallPosition wallPosition)
    {
        return walls[(int)wallPosition];
    }

    public void MakeMove(MoveDirection moveDirection)
    {
        switch (moveDirection)
        {
            case MoveDirection.R:
            case MoveDirection.Lp:
                TransferWalls(WallPosition.Top, WallPosition.Back, WallPosition.Bottom, WallPosition.Front);
                break;
            case MoveDirection.Rp:
            case MoveDirection.L:
                TransferWalls(WallPosition.Front, WallPosition.Bottom, WallPosition.Back, WallPosition.Top);
                break;
            case MoveDirection.D:
            case MoveDirection.Up:
                TransferWalls(WallPosition.Front, WallPosition.Right, WallPosition.Back, WallPosition.Left);
                break;
            case MoveDirection.Dp:
            case MoveDirection.U:
                TransferWalls(WallPosition.Left, WallPosition.Back, WallPosition.Right, WallPosition.Front);
                break;
            case MoveDirection.F:
            case MoveDirection.Bp:
                TransferWalls(WallPosition.Top, WallPosition.Right, WallPosition.Bottom, WallPosition.Left);
                break;
            case MoveDirection.Fp:
            case MoveDirection.B:
                TransferWalls(WallPosition.Left, WallPosition.Bottom, WallPosition.Right, WallPosition.Top);
                break;
        }
    }

    void TransferWalls(WallPosition wall1, WallPosition wall2, WallPosition wall3, WallPosition wall4)
    {
        WallColor temp = walls[(int)wall4];
        walls[(int)wall4] = walls[(int)wall3];
        walls[(int)wall3] = walls[(int)wall2];
        walls[(int)wall2] = walls[(int)wall1];
        walls[(int)wall1] = temp;
    }

}
