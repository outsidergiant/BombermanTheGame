using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MovingBase
{

    private int xDir = 0;
    private int zDir = 0;
    private List<int[]> directions;
    private BombManager bombManager;

    protected override void OnStart()
    {
        base.OnStart();
        speed = SpeedTypes.Slowest;
        bombManager = GetComponent<BombManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CalcEnemyDirection();
        AttemptMove(xDir, zDir);
    }

    protected virtual void InitPossibleDirections()
    {
        directions = new List<int[]>();
        int[] x = new int[] { -1, 0, 1 };
        int[] z = new int[] { -1, 0, 1 };
        directions.Add(x);
        directions.Add(z);
    }

<<<<<<< HEAD
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
=======
        int[] direction = directions[Random.RandomRange(0, directions.Count)];
        int xDir = 0;
        int zDir = 0;
        if (Random.RandomRange(0, directions.Count) == 0)
        {
            xDir = directions[0][Random.RandomRange(0, 3)];
        } else
        {
            zDir = directions[1][Random.RandomRange(0, 3)];
>>>>>>> origin/master
        }
    }

    protected override void AttemptMove(int xDir, int zDir)
    {
        RaycastHit hit;
        Move(xDir, zDir, out hit);
        //bombManager.DropNewBomb(this.transform.position);
    }
}
