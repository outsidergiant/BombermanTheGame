using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovingBase
{
    public GameObject bombObject;
    public int playerBombNumber;
    public int explosionRadius;

    private BombManager bombManager;


    // Use this for initialization
    protected override void OnStart()
    {
        base.OnStart();
        speed = SpeedTypes.Normal;
        bombManager = GetComponent<BombManager>();
    }

    void Update()
    {
        MonitorInput();
    }

    protected virtual void MonitorInput()
    {
        CheckPlayerActions();
        CheckMovingAttempts();
    }

    protected virtual void CheckPlayerActions()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (bombManager.bombs.Count < playerBombNumber)
            {
                Debug.Log("Bomb Manager Count: " + bombManager.bombs.Count);
                //Bomb bomb = new Bomb(Instantiate(bombObject));
                //bomb.explosionRadius = explosionRadius;
                bombManager.DropNewBomb(this.transform.position);
            }
        }
    }

    protected virtual void CheckMovingAttempts()
    {
        int horizontal = 0;
        int vertical = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1;
        }

        if (horizontal != 0)
        {
            vertical = 0;
        }
        if (horizontal != 0 || vertical != 0)
        {
            AttemptMove(horizontal, vertical);
        }
    }

    protected override void AttemptMove(int xDir, int zDir)
    {

        RaycastHit hit;
        if (Move(xDir, zDir, out hit))
        {

            //end = transform.position + new Vector3(xDir, 0f, zDir);
            //end.x = (float)Math.Round(end.x);
            //end.z = (float)Math.Round(end.z);
            //Sounds...
        }
        CheckIfGameOver();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
        }
    }

    protected virtual void CheckIfGameOver() { }

}
