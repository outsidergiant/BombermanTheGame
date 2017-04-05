using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase {

    public int intelligence;
    public int numberOfPoints;

    public Enemy(int intelligence, int numberOfPoints, SpeedTypes speed) : base()
    {
        this.intelligence = intelligence;
        this.numberOfPoints = numberOfPoints;
        this.speed = speed;
    }

}
