using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MovingBase
{

    // Use this for initialization
    void Start()
    {
        base.Start();
        speed = SpeedTypes.Slowest;
    }

    // Update is called once per frame
    void Update()
    {
        List<int[]> directions = new List<int[]>();
        int[] x = new int[] { -1, 0, 1 };
        int[] z = new int[] { -1, 0, 1 };
        directions.Add(x);
        directions.Add(z);

        int[] direction = directions[Random.RandomRange(0, directions.Count)];
        int xDir = 0;
        int zDir = 0;
        if (Random.RandomRange(0, directions.Count) == 0)
        {
            xDir = directions[0][Random.RandomRange(0, 3)];
        } else
        {
            zDir = directions[1][Random.RandomRange(0, 4)];
        }
        AttemptMove(xDir, zDir);
    }

    protected override void AttemptMove(int xDir, int zDir)
    {
        RaycastHit hit;
        Move(xDir, zDir, out hit);
    }
}
