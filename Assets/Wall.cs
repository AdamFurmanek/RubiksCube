using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class Wall : MonoBehaviour
{
    Cube cube;

    WallType wallType;

    private void Awake()
    {
        cube = transform.parent.GetComponent<Cube>();

        wallType = (WallType)Enum.Parse(typeof(WallType), gameObject.name);
    }

    public void MakeMove(MoveDirection moveDirection, bool prim)
    {
        RegisterToWall();
        RotateWall(moveDirection, prim);
        UnregisterFromWall();
    }

    void RegisterToWall()
    {
        foreach (var cubie in cube.GetCubies())
            if (cubie.CanRegisterToWall(wallType))
                cubie.transform.SetParent(transform);
    }

    void RotateWall(MoveDirection moveDirection, bool prim)
    {
        switch (wallType)
        {
            case WallType.F1:
            case WallType.F2:
            case WallType.F3:
                transform.Rotate(new Vector3(0, 0, prim? 90 : - 90), Space.Self);
                break;
            case WallType.U1:
            case WallType.U2:
            case WallType.U3:
                transform.Rotate(new Vector3(0, prim? -90 : 90, 0), Space.Self);
                break;
            case WallType.R1:
            case WallType.R2:
            case WallType.R3:
                transform.Rotate(new Vector3(prim ? -90 : 90, 0, 0), Space.Self);
                break;
        }

        var cubies = new List<Cubie>();
        for (int i = 0; i < transform.childCount; i++)
            cubies.Add(transform.GetChild(i).GetComponent<Cubie>());

        foreach (var cubie in cubies)
            cubie.MakeMove(moveDirection);
    }

    void UnregisterFromWall()
    {
        var cubies = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
            cubies.Add(transform.GetChild(i));

        foreach (var cubie in cubies)
            cubie.SetParent(cube.GetFreeRoot());
    }
}
