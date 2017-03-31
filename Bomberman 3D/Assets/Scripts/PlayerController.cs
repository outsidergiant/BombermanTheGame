using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovingBase
{
<<<<<<< HEAD
=======
    public Rigidbody rigidBody;
>>>>>>> origin/master
    public GameObject bombObject;
    public int playerBombNumber;
    public int explosionRadius;

<<<<<<< HEAD
=======
    private int frameCounter = 0;
    private Vector3 end;
>>>>>>> origin/master
    private BombManager bombManager;


    // Use this for initialization
    protected override void OnStart()
    {
        base.OnStart();
        speed = SpeedTypes.Normal;
        bombManager = GetComponent<BombManager>();
<<<<<<< HEAD
=======
        //bomb = Instantiate(bomb, this.gameObject.transform.position, Quaternion.identity) as GameObject;
        //bomb.SetActive(isBombActive);
>>>>>>> origin/master
    }

    void Update()
    {
        MonitorInput();
<<<<<<< HEAD
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
=======

        //if (isBombActive)
        //{
        //    timeToExplode -= Time.deltaTime;
        //    if (timeToExplode <= 0) {
        //        ExplodeTheBomb();
        //    }
        //}

        //if (transform.position != end && end.x != 0 && end.y != 0 && end.z != 0)
        //{
        //    frameCounter++;
        //    if (frameCounter == 10)
        //    {
        //        frameCounter = 0;
        //        end = transform.position;
        //    }
        //    float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        //    Vector3 newPostion = Vector3.MoveTowards(rigidBody.position, end, speed * Time.deltaTime);

        //    transform.position = newPostion;
        //    sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        //}
>>>>>>> origin/master
    }

    protected virtual void MonitorInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (bombManager.bombs.Count < playerBombNumber)
            {
                Debug.Log("Bomb Manager Count: " + bombManager.bombs.Count);
                Bomb bomb = new Bomb(Instantiate(bombObject));//GetComponent<Bomb>();//new Bomb();
                //bombObject.SetActive(true);
                //bomb.bombPrefab = bombObject;
                bomb.explosionRadius = explosionRadius;
                bombManager.DropNewBomb(bomb, this.transform.position);

            }

        }
        else
        {
            int horizontal = 0;
            int vertical = 0;
            horizontal = (int)(Input.GetAxisRaw("Horizontal"));
            vertical = (int)(Input.GetAxisRaw("Vertical"));
            if (horizontal != 0)
            {
                vertical = 0;
            }
            if (horizontal != 0 || vertical != 0)
            {
                AttemptMove(horizontal, vertical);
            }
        }
    }

    //protected virtual void DropTheBomb()
    //{
    //    isBombActive = true;
    //    bomb.transform.position = this.transform.position;
    //    bomb.SetActive(isBombActive);
    //    Debug.Log("Drop the bomb");
    //    //activeBomb =
    //      //          Instantiate(bomb, this.gameObject.transform.position, Quaternion.identity) as GameObject;
    //    //activeBomb.SetActive(true);

    //}

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
<<<<<<< HEAD
=======

    protected virtual void CheckIfGameOver() { }
>>>>>>> origin/master

    protected virtual void CheckIfGameOver() { }

}
