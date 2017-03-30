using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BombManager : MonoBehaviour
{

    //public bool isBombActive = false;
    public List<Bomb> bombs;
    //public int explosionRadius;
    //public int playerBombNumber = 1;
    //public float timeToExplode = 2f;

    void Update()
    {
        for (int i = 0; i < bombs.Count; i++) {
            Bomb bomb = bombs[i];
            bomb.timeToExplode -= Time.deltaTime;
            if (bomb.timeToExplode <= 0)
            {
                Explode(bomb);
            }
        }
    }

    public BombManager()
    {
        bombs = new List<Bomb>();
    }

    private void bomb_BombExploded(object sender, System.EventArgs e)
    {
        Bomb bomb = sender as Bomb;
        if (bomb != null)
        {
            Explode(bomb);
        }
    }

    private void Explode(Bomb bomb)
    {
        //bomb.BombPrefab;
        //bomb.IsBombActive = false;
        bomb.BombPrefab.SetActive(false);
        //Debug.Log("Before remove: " + bombs.Count);
        bombs.Remove(bomb);
        //Debug.Log("After remove: " + bombs.Count);
    }

    public void DropNewBomb(Bomb bomb, Vector3 position)
    {
        position.x = (float)Math.Round(position.x);
        position.z = (float)Math.Round(position.z);
        //Debug.Log("DROP NEW " + bomb.bombPrefab);
        //bomb.IsBombActive = true;
        bomb.BombPrefab.transform.position = position;
        bomb.BombPrefab.SetActive(true);
        bomb.BombExploded += bomb_BombExploded;
        bombs.Add(bomb);
        Debug.Log(position);

    }
}


