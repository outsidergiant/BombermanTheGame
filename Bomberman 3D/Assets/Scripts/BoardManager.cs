﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }


    public int columns = GlobalParameters.numberTilesX;
    public int rows = GlobalParameters.numberTilesZ;
    public Count wallCount = new Count(5, 9);
    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] brickWallTiles;
    public GameObject[] enemyTiles;
    public GameObject[] concreteWallTiles;
    public GameObject player;                         

    private Transform boardHolder;                                 
    private List<Vector3> gridPositions = new List<Vector3>();
    private float y = 0f;

    void InitialiseList()
    {
        gridPositions.Clear();
        for (int x = 1; x < columns - 1; x++)
        {
            for (int z = 1; z < rows - 1; z++)
            {
                if (x % 2 == 0 && z % 2 == 0)
                {
                    GameObject toInstantiate = concreteWallTiles[Random.Range(0, concreteWallTiles.Length)];
                    InstantiateGameObject(toInstantiate, x, z);
                }
                else
                {
                    gridPositions.Add(new Vector3(x, y, z));
                    //Debug.Log(x + "  " + z);
                }
            }
        }
    }

    void InstantiateGameObject(GameObject toInstantiate, int x, int z)
    {
        GameObject instance =
                    Instantiate(toInstantiate, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        instance.transform.SetParent(boardHolder);
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = 0; x < columns + 1; x++)
        {
            for (int z = 0; z < rows + 1; z++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == 0 || x == columns || z == 0 || z == rows)
                    toInstantiate = concreteWallTiles[Random.Range(0, concreteWallTiles.Length)];

                InstantiateGameObject(toInstantiate, x, z);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
            if (tileChoice.CompareTag("Brick") && i == 0)
            {
                Instantiate((Resources.Load(@"Exit") as GameObject), randomPosition, Quaternion.identity);
            }
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(brickWallTiles, wallCount.minimum, wallCount.maximum);
        GameObject playerObject = FactoryContainer.Instance.Resolve<PlayerFactory>().GetObject();
        LayoutObjectAtRandom(new GameObject[] {playerObject}, 1, 1);
        //Debug.Log("position: " + player.transform.position);
        //int enemyCount = (int)Mathf.Log(level, 2f);
        enemyTiles = new GameObject[] {
            FactoryContainer.Instance.Resolve<Enemy1Factory>().GetObject(),
            FactoryContainer.Instance.Resolve<Enemy2Factory>().GetObject()
        };
        LayoutObjectAtRandom(enemyTiles, 1, 5);
        
        
        //Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }
}
