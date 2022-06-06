using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class Cube : MonoBehaviour
{
    Wall F1;
    Wall F2;
    Wall F3;
    Wall U1;
    Wall U2;
    Wall U3;
    Wall R1;
    Wall R2;
    Wall R3;

    Transform freeRoot;

    Cubie[] cubies;

    private void Awake()
    {
        F1 = transform.Find("F1").GetComponent<Wall>();
        F2 = transform.Find("F2").GetComponent<Wall>();
        F3 = transform.Find("F3").GetComponent<Wall>();
        U1 = transform.Find("U1").GetComponent<Wall>();
        U2 = transform.Find("U2").GetComponent<Wall>();
        U3 = transform.Find("U3").GetComponent<Wall>();
        R1 = transform.Find("R1").GetComponent<Wall>();
        R2 = transform.Find("R2").GetComponent<Wall>();
        R3 = transform.Find("R3").GetComponent<Wall>();

        freeRoot = transform.Find("Free");

        cubies = GetComponentsInChildren<Cubie>();
    }

    public Cubie[] GetCubies()
    {
        return cubies;
    }

    public Transform GetFreeRoot()
    {
        return freeRoot;
    }

    void MakeMove(MoveDirection moveDirection, bool prim)
    {
        GetWall(moveDirection).MakeMove(moveDirection, prim);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.P))
                MakeMove(MoveDirection.RLp, true);
            if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.L))
                MakeMove(MoveDirection.RL, false);

            if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.P))
                MakeMove(MoveDirection.Rp, true);
            else if (Input.GetKey(KeyCode.R))
                MakeMove(MoveDirection.R, false);

            else if(Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.P))
                MakeMove(MoveDirection.Lp, true);
            else if (Input.GetKey(KeyCode.L))
                MakeMove(MoveDirection.L, false);

            if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.P))
                MakeMove(MoveDirection.FBp, true);
            if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.B))
                MakeMove(MoveDirection.FB, false);

            else if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.P))
                MakeMove(MoveDirection.Fp, true);
            else if (Input.GetKey(KeyCode.F))
                MakeMove(MoveDirection.F, false);

            else if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.P))
                MakeMove(MoveDirection.Bp, true);
            else if (Input.GetKey(KeyCode.B))
                MakeMove(MoveDirection.B, false);

            if (Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.P))
                MakeMove(MoveDirection.UDp, true);
            if (Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.D))
                MakeMove(MoveDirection.UD, false);

            else if (Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.P))
                MakeMove(MoveDirection.Up, true);
            else if (Input.GetKey(KeyCode.U))
                MakeMove(MoveDirection.U, false);

            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.P))
                MakeMove(MoveDirection.Dp, true);
            else if (Input.GetKey(KeyCode.D))
                MakeMove(MoveDirection.D, false);
        }
    }

    Wall GetWall(MoveDirection moveDirection)
    {
        switch (moveDirection)
        {
            case MoveDirection.R:
            case MoveDirection.Rp:
                return R3;
            case MoveDirection.L:
            case MoveDirection.Lp:
                return R1;
            case MoveDirection.RL:
            case MoveDirection.RLp:
                return R2;
            case MoveDirection.U:
            case MoveDirection.Up:
                return U1;
            case MoveDirection.D:
            case MoveDirection.Dp:
                return U3;
            case MoveDirection.UD:
            case MoveDirection.UDp:
                return U2;
            case MoveDirection.F:
            case MoveDirection.Fp:
                return F1;
            case MoveDirection.B:
            case MoveDirection.Bp:
                return F3;
            case MoveDirection.FB:
            case MoveDirection.FBp:
                return F2;
            default:
                return null;
        }
    }
}
