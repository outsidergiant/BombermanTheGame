using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBombFactory
{
    GameObject GetBomb();
}
public class BombFactory : IFactory//IBombFactory
{
    //public GameObject GetBomb()
    public GameObject GetObject()
    {
        return Resources.Load(@"Bomb") as GameObject;
    }
}
