using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Factory : IFactory
{
    public GameObject GetObject()
    {
        return Resources.Load(@"Enemy 2") as GameObject;
    }
}
