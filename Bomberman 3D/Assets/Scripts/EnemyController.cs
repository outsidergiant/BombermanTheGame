using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterControllerBase
{

    private int xDir = 0;
    private int zDir = 0;
    private Enemy enemy;
    private List<int[]> directions;
    private BombManager bombManager;

    protected override void OnStart()
    {
        base.OnStart();
        enemy = new Enemy(1, 1, SpeedTypes.Slowest);
        bombManager = GetComponent<BombManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CalcEnemyDirection();
        RaycastHit hit;
        Move(xDir, zDir, out hit, enemy.speed);
    }

    protected virtual void InitPossibleDirections()
    {
        directions = new List<int[]>();
        int[] x = new int[] { -1, 0, 1 };
        int[] z = new int[] { -1, 0, 1 };
        directions.Add(x);
        directions.Add(z);
    }

    protected virtual void CalcEnemyDirection()
    {
        InitPossibleDirections();
        ChooseRandomDirection();
    }

    protected virtual void ChooseRandomDirection()
    {
        if (Random.Range(0, directions.Count) == 0)
        {
            xDir = directions[0][Random.Range(0, 3)];
        }
        else
        {
            zDir = directions[1][Random.Range(0, 3)];
        }

        if (Random.Range(0, directions.Count) == 0)
        {
            xDir = directions[0][Random.Range(0, 3)];
        } else
        {
            zDir = directions[1][Random.Range(0, 3)];
        }
    }

    //protected override void AttemptMove(int xDir, int zDir)
    //{
    //    RaycastHit hit;
    //    Move(xDir, zDir, out hit, enemy.speed);
    //}
}
