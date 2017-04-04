using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpeedTypes
{
    Slowest = 1, Slow = 2, Normal = 3
}


public class CharacterBase {

    //public Rigidbody rigidbody;
    public GameObject gameObject;
    public Dictionary<Type, Type> abilities;
    public SpeedTypes speed;

    public CharacterBase()
    {
        abilities = new Dictionary<Type, Type>();
    }

    //void Start()
    //{
    //    OnStart();
    //}

    //protected virtual void OnStart()
    //{
    //    movingBehaviour = new MovingBehaviourBase();
    //    abilities = new Dictionary<Type, Type>();
    //}

}
