using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPurchase : MonoBehaviour
{
    public PlayerController player;
    public Camera cam;

    public GameObject managerGO;
    public GameManager manager;
    public UIManager uiManage;

    public RaycastHit hit;

    public int healthCost = 1500;

    public float increaseAmount = 50f;
    private int purchaseLevel = 1;

    public GameObject pricePrompt;

    [SerializeField]
    private int price;

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
        manager = managerGO.GetComponent<GameManager>();
        uiManage = managerGO.GetComponent<UIManager>();

        price = healthCost * purchaseLevel;
    }

    void ShopBuy()
    {
        if(inRange && player.playerPoints >= (healthCost * purchaseLevel))
        {
            player.playerPoints -= (healthCost * purchaseLevel);

            player.maxHealth += increaseAmount;

            uiManage.PointUpdate();

            purchaseLevel++;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.GetComponent<PlayerController>();

            inRange = true;

            pricePrompt.SetActive(true);
            pricePrompt.GetComponent<TextMeshProUGUI>().text = "Press F to Buy Health, Cost: " + price;
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
