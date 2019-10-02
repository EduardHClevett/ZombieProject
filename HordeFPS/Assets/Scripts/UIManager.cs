using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject roundDisplay;
    public GameObject zombieDisplay;
    public GameObject pointDisplay;
    public GameObject ammoDisplay;
    public GameObject weaponLvlDisplay;
    public GameObject healthTxtDisplay;

    public GameObject highestRoundDisplay;

    public RectTransform healthBarFill;

    public GameManager manager;
    public GameObject player;
    public GameObject gun;
    public GameObject crosshair;

    public WeaponData gunComponent;
    public PlayerController playerControl;

    void Awake()
    {
        manager = GetComponent<GameManager>();

        player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        RoundUpdate();
        ZombieUpdate();
        PointUpdate();

        if (highestRoundDisplay != null)
            highestRoundDisplay.GetComponent<TextMeshProUGUI>().text = "Highest Round: " + PlayerPrefs.GetInt("Highest Round");
    }

    void Update()
    {
        gun = GameObject.FindWithTag("Weapon");

        if(gun != null)
            gunComponent = gun.GetComponent<WeaponData>();

        AmmoUpdate();
        WeaponLvlUpdate();

        if(playerControl != null)
            HealthUpdate(playerControl.GetHealthPercent());

        try
        {
            gun = GameObject.FindWithTag("Weapon");
            gunComponent = gun.GetComponent<WeaponData>();
        }
        catch {}

        try
        {
            player = GameObject.FindWithTag("Player");
        }
        catch {}
    }

    public void RoundUpdate()
    {
        if(roundDisplay != null)
        {
            roundDisplay.GetComponent<TextMeshProUGUI>().text = "Round " + manager.round;
        }
    }

    public void ZombieUpdate()
    {
        if(zombieDisplay != null)
        {
            zombieDisplay.GetComponent<TextMeshProUGUI>().text = "Zombies Remaining: " + (manager.zombiesInRound - manager.zombiesKilledThisRound);
        }
    }

    public void PointUpdate()
    {
        if(pointDisplay != null)
        {
            pointDisplay.GetComponent<TextMeshProUGUI>().text = "" + playerControl.playerPoints;
        }
    }

    public void AmmoUpdate()
    {
        if(gunComponent != null)
        {
            ammoDisplay.GetComponent<TextMeshProUGUI>().text = gunComponent.currentMag + "/" + gunComponent.currentReserve;
        }
    }

    public void HealthUpdate(float amount)
    {
        if(healthBarFill != null)
        {
            //healthBarFill.localScale = new Vector3(amount, 1f, 1f);
            healthBarFill.GetComponent<Image>().fillAmount = amount;
        }

        healthTxtDisplay.GetComponent<TextMeshProUGUI>().text = playerControl.health + "/" + playerControl.maxHealth;
    }

    public void WeaponLvlUpdate()
    {
        if(weaponLvlDisplay != null)
        {
            weaponLvlDisplay.GetComponent<TextMeshProUGUI>().text = "Weapon Level " + gunComponent.weaponLevel;
        }
    }

    public void HideCrosshair(bool hide)
    {
        if(hide == true)
        {
            crosshair.SetActive(false);
        }
        else if(hide == false)
        {
            crosshair.SetActive(true);
        }
    }
}
