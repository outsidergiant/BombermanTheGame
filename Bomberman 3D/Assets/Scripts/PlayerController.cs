using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum SpeedTypes
//{
//    Slowest = 1, Slow = 2, Normal = 3
//}

public class PlayerController : CharacterControllerBase
{
    private Player player;
    private BombManager bombManager;

    void Start()
    {
        player = new Player();
        bombManager = GetComponent<BombManager>();
        base.OnStart();
    }

    void Update()
    {
        MonitorInput();
    }

    public virtual void MonitorInput( )
    {
        CheckPlayerActions();
        CheckMovingAttempts();
    }

    protected virtual void CheckPlayerActions()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (bombManager == null) return;
            if (bombManager.bombs.Count < player.playerBombNumber)
            {
                bombManager.DropNewBomb(transform.position);
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
            RaycastHit hit;
            Move(horizontal, vertical, out hit, player.speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
