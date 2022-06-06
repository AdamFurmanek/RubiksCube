using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Cubie[] cubies;

    private void Awake()
    {
        cubies = GetComponentsInChildren<Cubie>();
    }
}
