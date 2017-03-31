using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {


    //public static string 

    //public static GameObject GetBombPrefab()//string bombPath)
    //{
    //    return Resources.Load(bombPath) as GameObject;
    //}
    
}
public interface IBombFactory
{
    GameObject GetBomb();
}
public class BombFactory : IBombFactory
{
    public GameObject GetBomb()
    {
        return Resources.Load(@"Bomb") as GameObject;
    }
}
public class FactoryContainer
{
    private static FactoryContainer container;
    private Dictionary<Type, Type> factories;
    protected FactoryContainer()
    {
        factories = new Dictionary<Type, Type>();
    }
    public static FactoryContainer Instance
    {
        get {
            if(container == null)
            {
                container = new FactoryContainer();
            }
            return container;
        }
    }
    public void Register<TSource, TTarget>()
        where TTarget : class, TSource, new()
    {
        factories[typeof(TSource)] = typeof(TTarget);
    }
    public TSource Resolve<TSource>()
    {
        if (factories.ContainsKey(typeof(TSource)))
        {
            return (TSource)Activator.CreateInstance(factories[typeof(TSource)]);
        }
        return default(TSource);
    }
}
