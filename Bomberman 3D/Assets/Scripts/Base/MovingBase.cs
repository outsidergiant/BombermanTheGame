using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpeedTypes
{
    Slowest= 1, Slow = 2, Normal = 3
}

public abstract class MovingBase : MonoBehaviour {

    

    private Rigidbody rigidBody;
    private float movementTime = 1f;
    //private float speed = 3f;
    private float inverseSpeed;
    private float startTime;

    protected SpeedTypes speed;

    private int lockMove;

    protected virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {

    }

    protected abstract void AttemptMove(int xDir, int zDir);

    protected void TurnHead(int xDir, int zDir)
    {
        if (xDir == -1)
            transform.eulerAngles = new Vector3(0, 180, 0);
        if (xDir == 1)
            transform.eulerAngles = new Vector3(0, 0, 0);
        if (zDir == -1)
            transform.eulerAngles = new Vector3(0, 90, 0);
        if (zDir == 1)
            transform.eulerAngles = new Vector3(0, -90, 0);
    }



    protected bool Move(int xDir, int zDir, out RaycastHit hit)
    {
        
        Vector3 start = transform.position;
        Vector3 end = start + new Vector3(xDir, 0f, zDir);
        Debug.Log(Physics.Linecast(start, end, out hit));
        if (hit.transform == null)
        {
            if (lockMove == 0)
            {
                TurnHead(xDir, zDir);
                StartCoroutine(SmoothMovement(end));
            }
                
            return true;
        }
        return false;
    }

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        StartMove();

        float journeyLength = (float)Math.Round((transform.position - end).magnitude, 3);
        
        while (journeyLength > 0f)
        {
            Vector3 newPostion = Vector3.MoveTowards(rigidBody.position, end, (int)speed * Time.deltaTime);
            //t++;
            rigidBody.MovePosition(newPostion);

            journeyLength = (float)Math.Round((transform.position - end).magnitude, 3);
            yield return null;
        }
        StopMove();
    }

    private void StartMove()
    {
        lockMove++;
    }

    private void StopMove()
    {
        lockMove--;
    }
}
