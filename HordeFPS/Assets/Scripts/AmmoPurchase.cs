using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoPurchase : MonoBehaviour
{
    public GameObject gun;
    public WeaponData gunComponent;

    public Camera cam;
    public PlayerController player;

    public GameObject managerGO;
    public UIManager uiManage;

    public RaycastHit hit;

    public int ammoCost = 500;

    public GameObject pricePrompt;

    public Inputs input;
    public bool inRange = false;

    void Awake()
    {
        input = new Inputs();

        input.InGame.Interact.performed += _ => ShopBuy();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }
    void Update()
    {
        cam = Camera.main;

        managerGO = GameObject.FindWithTag("GameController");
        uiManage = managerGO.GetComponent<UIManager>();

        try
        {
            gun = GameObject.FindWithTag("Weapon");
            gunComponent = gun.GetComponent<WeaponData>();
        }
        catch
        {
            Debug.Log("Weapon object is null!");
        }

        ammoCost = (gunComponent.weaponCost / 2) * gunComponent.weaponLevel;
    }

    void ShopBuy()
    {
        if(inRange && player.playerPoints >= ammoCost)
        {
            gunComponent.currentReserve = gunComponent.maxReserve;

            player.playerPoints -= ammoCost;

            uiManage.PointUpdate();
            uiManage.AmmoUpdate();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = other.GetComponent<PlayerController>();

            inRange = true;

            pricePrompt.SetActive(true);
            pricePrompt.GetComponent<TextMeshProUGUI>().text = "Press F to Buy Ammo, Cost: " + ammoCost;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = null;

            inRange = false;

            pricePrompt.SetActive(false);
        }
    }
}
