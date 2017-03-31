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

        if (Random.RandomRange(0, directions.Count) == 0)
        {
            xDir = directions[0][Random.RandomRange(0, 3)];
        } else
        {
            zDir = directions[1][Random.RandomRange(0, 3)];
        }
    }

    float x = 5f;

    protected override void AttemptMove(int xDir, int zDir)
    {
        RaycastHit hit;
        Move(xDir, zDir, out hit);
        //if (bombManager != null)
        //{
        //    //Debug.Log(x);
        //    if (x <= 0)
        //    {
        //        bombManager.DropNewBomb(this.transform.position);
        //        x = 5f;
        //    }
        //    //x -= Time.deltaTime;
            
        //}
    }
}
