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

    int wallF; //need to be setted on makemove
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
        if (transform.localPosition.z < 0)
            wallF = 1;
        if (transform.localPosition.z > 0)
            wallF = 3;

        wallR = 2;
        if (transform.localPosition.x < 0)
            wallR = 1;
        if (transform.localPosition.x > 0)
            wallR = 3;

        wallU = 2;
        if (transform.localPosition.y < 0)
            wallU = 3;
        if (transform.localPosition.y > 0)
            wallU = 1;
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
            case MoveDirection.RL:
                TransferWalls(WallPosition.Top, WallPosition.Back, WallPosition.Bottom, WallPosition.Front);
                break;
            case MoveDirection.Rp:
            case MoveDirection.L:
            case MoveDirection.RLp:
                TransferWalls(WallPosition.Front, WallPosition.Bottom, WallPosition.Back, WallPosition.Top);
                break;
            case MoveDirection.U:
            case MoveDirection.Dp:
            case MoveDirection.UD:
                TransferWalls(WallPosition.Left, WallPosition.Back, WallPosition.Right, WallPosition.Front);
                break;
            case MoveDirection.Up:
            case MoveDirection.D:
            case MoveDirection.UDp:
                TransferWalls(WallPosition.Front, WallPosition.Right, WallPosition.Back, WallPosition.Left);
                break;

            case MoveDirection.F:
            case MoveDirection.Bp:
            case MoveDirection.FB:
                TransferWalls(WallPosition.Top, WallPosition.Right, WallPosition.Bottom, WallPosition.Left);
                break;
            case MoveDirection.Fp:
            case MoveDirection.B:
            case MoveDirection.FBp:
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

    public bool CanRegisterToWall(WallType wallType)
    {
        switch (wallType)
        {
            case WallType.F1: return wallF == 1;
            case WallType.F2: return wallF == 2;
            case WallType.F3: return wallF == 3;

            case WallType.R1: return wallR == 1;
            case WallType.R2: return wallR == 2;
            case WallType.R3: return wallR == 3;

            case WallType.U1: return wallU == 1;
            case WallType.U2: return wallU == 2;
            case WallType.U3: return wallU == 3;

            default: return false;
        }
    }

}
