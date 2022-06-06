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
        var cubies = new List<Cubie>();
        foreach (var cubie in cube.GetCubies())
            if (cubie.CanRegisterToWall(wallType))
                cubies.Add(cubie);

        RegisterToWall(cubies);
        RotateWall(prim);
        if (cube.unregister)
        {
            UnregisterFromWall(cubies);
            SaveMove(cubies, moveDirection);
        }
    }

    void RegisterToWall(List<Cubie> cubies)
    {
        foreach (var cubie in cubies)
            cubie.transform.SetParent(transform);
    }

    void RotateWall(bool prim)
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

    }

    void UnregisterFromWall(List<Cubie> cubies)
    {
        foreach (var cubie in cubies)
            cubie.transform.SetParent(cube.GetFreeRoot());
    }

    void SaveMove(List<Cubie> cubies, MoveDirection moveDirection)
    {
        foreach (var cubie in cubies)
            cubie.SaveMove(moveDirection);
    }

}
