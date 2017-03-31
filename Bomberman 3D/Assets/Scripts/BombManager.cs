using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BombManager : MonoBehaviour
{
<<<<<<< HEAD
    public List<Bomb> bombs;
    public GameObject blastWave;

    private PlayerController playerController;
    private List<GameObject> waves;
    private float wavesTTL = 0.5f;
    private GameManager gameManager;
    private IBombFactory bombFactory;

    void Update()
    {
        UpdateBombTTL();
        RemoveBlastWaves();
    }

    protected virtual void RemoveBlastWaves()
    {
        if (waves != null)
        {
            wavesTTL -= Time.deltaTime;
            if (wavesTTL <= 0)
            {
                foreach (GameObject wave in waves)
                {
                    wave.SetActive(false);
                }
                wavesTTL = 0.5f;
                waves = null;
            }

        }
    }

    protected virtual void UpdateBombTTL()
    {
        for (int i = 0; i < bombs.Count; i++)
        {
=======

    //public bool isBombActive = false;
    public List<Bomb> bombs;
    //public int explosionRadius;
    //public int playerBombNumber = 1;
    //public float timeToExplode = 2f;

    void Update()
    {
        for (int i = 0; i < bombs.Count; i++) {
>>>>>>> origin/master
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
<<<<<<< HEAD
        bombFactory = FactoryContainer.Instance.Resolve<IBombFactory>();
    }

    protected virtual void Explode(Bomb bomb)
    {
        bomb.BombPrefab.SetActive(false);
        CreateBlastWave(bomb);
        bombs.Remove(bomb);

    }

    protected virtual void CreateBlastWave(Bomb bomb)
    {
        Transform transform = bomb.BombPrefab.transform;
        //playerController = GetComponent<PlayerController>();
        waves = new List<GameObject>();
        waves.Add(Instantiate(blastWave, transform.position, Quaternion.identity));
        MakeWaveGo(bomb, transform.forward);
        MakeWaveGo(bomb, transform.forward * -1);
        MakeWaveGo(bomb, transform.right);
        MakeWaveGo(bomb, transform.right * -1);
    }

    protected virtual void MakeWaveGo(Bomb bomb, Vector3 direction)
    {
        int radius = bomb.explosionRadius;
        Vector3 position = bomb.BombPrefab.transform.position;
        for (int i = 0; i < radius; i++)
        {
            position += direction;
            waves.Add(Instantiate(blastWave, position, Quaternion.identity));

        }
    }

    public void DropNewBomb(Vector3 position)
    {
        Bomb bomb = new Bomb(bombFactory.GetBomb());
        position.x = (float)Math.Round(position.x);
        position.z = (float)Math.Round(position.z);
        bomb.BombPrefab.transform.position = position;
        bomb.BombPrefab.SetActive(true);
        Instantiate(bomb.BombPrefab);
        bombs.Add(bomb);
    }

    //public void GetNewBomb()
    //{

    //}
=======
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
>>>>>>> origin/master
}


