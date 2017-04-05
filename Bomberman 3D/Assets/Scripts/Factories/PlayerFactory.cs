using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : IFactory
{
    public GameObject GetObject()
    {
        return Resources.Load(@"Player") as GameObject;
    }
}
