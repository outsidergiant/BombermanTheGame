using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Factory : IFactory {

    public GameObject GetObject()
    {
        return Resources.Load(@"Enemy 1") as GameObject;
    }
}
