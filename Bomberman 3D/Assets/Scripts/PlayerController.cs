using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovingBase
{
    public Rigidbody rigidBody;
    private int frameCounter = 0;
    private Vector3 end;

    // Use this for initialization
    void Start()
    {
        base.Start();
        speed = SpeedTypes.Normal;
    }

    void Update()
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

    protected virtual void CheckIfGameOver() { }


}
