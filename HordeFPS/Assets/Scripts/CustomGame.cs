using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomGame : MonoBehaviour
{
    public int customStartRound = 1;
    public int customStartPoints = 0;
    public int customZombRatio = 5;

    public bool isCustom;

    public GameObject customOptions;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("CustomGame");

        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetStartRound(string feed)
    {
        int feedInt = int.Parse(feed);

        customStartRound = feedInt;
    }

    public void SetStartPoints(string feed)
    {
        int feedInt = int.Parse(feed);

        customStartPoints = feedInt;
    }

    public void SetZombRatio(string feed)
    {
        int feedInt = int.Parse(feed);

        customZombRatio = feedInt;
    }

    public void CustomToggle(bool feed)
    {
        isCustom = feed;

        customOptions.SetActive(!customOptions.activeSelf);
    }
}
