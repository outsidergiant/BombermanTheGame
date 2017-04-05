using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase {

    public int playerBombNumber;
    public int explosionRadius;
    //public BombManager bombManager;

    public Player() : base()
    {
        speed = SpeedTypes.Normal;
        explosionRadius = 1;
        playerBombNumber = 1;
    }
}
