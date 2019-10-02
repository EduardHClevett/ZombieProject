using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradePurchase : MonoBehaviour
{
    public PlayerController player;

    public GameObject gun;
    public WeaponData gunComponent;

    public GameObject managerGO;
    public GameManager manager;
    public UIManager uiManage;

    public int upgradeCost = 5000;

    public float increaseAmount = 1000f;
    private int purchaseLevel = 1;

    public GameObject pricePrompt;

    public bool inRange = false;

    [SerializeField]
    private int price;

    public Inputs input;

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
        gun = GameObject.FindWithTag("Weapon");
        gunComponent = gun.GetComponent<WeaponData>();

        managerGO = GameObject.FindWithTag("GameController");
        manager = managerGO.GetComponent<GameManager>();
        uiManage = managerGO.GetComponent<UIManager>();

        price = upgradeCost + (gunComponent.weaponLevel * (int) increaseAmount);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.GetComponent<PlayerController>();

            pricePrompt.SetActive(true);
            pricePrompt.GetComponent<TextMeshProUGUI>().text = "Press F to Upgrade Weapon, Cost: " + price;

            inRange = true;
        }
    }

    void ShopBuy()
    {

        if (inRange && player.playerPoints >= price)
        {
            Debug.Log("Purchase triggered!");

            player.playerPoints -= price;

            gunComponent.weaponLevel++;
            gunComponent.extraMags++;

            uiManage.PointUpdate();

            purchaseLevel++;
        }
        else if (!inRange)
            return;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = null;
            pricePrompt.SetActive(false);

            inRange = false;
        }
    }
}
