using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.WSA;

public class Bomb //: INotifyPropertyChanged
{

    //public event PropertyChangedEventHandler PropertyChanged;
    public GameObject BombPrefab { get; set; }
    public int explosionRadius = 1;
    public float timeToExplode = 2f;

    //private bool isBombActive;
    //public bool IsBombActive
    //{
    //    get { return isBombActive; }
    //    set
    //    {
    //        isBombActive = value;
    //        //if (value)
    //            //OnPropertyChanged();

    //        //BombPrefab.SetActive(value);
    //    }
    //}



    private Timer timer;

    public event BombExplodedEventHandler BombExploded;

    public delegate void BombExplodedEventHandler(object sender, EventArgs e);

    public Bomb(GameObject prefab)
    {
        BombPrefab = prefab;
        //timer = new Timer(2000);
        //timer.Elapsed += timer_Elapsed;
    }

    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        //Debug.Log("BABAH!!!!!!!!!!!");
        //Debug.Log(this);

        System.Threading.Thread.Sleep(100);
        BombPrefab.SetActive(false);
        BombExploded(this, new EventArgs());
        //isBombActive = false;
        timer.Enabled = false;
        //Debug.Log("Stopped");
    }

    protected void OnPropertyChanged()
    {
        //Debug.Log("start timer");
        //timer.Start();
        //PropertyChangedEventHandler handler = PropertyChanged;
        //if (handler != null)
        //{
        //handler(this, new PropertyChangedEventArgs(name));
        //}
    }
}


