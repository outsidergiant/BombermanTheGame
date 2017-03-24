using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingBase : MonoBehaviour {

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
            return true;
        }
        return false;
    }
}
