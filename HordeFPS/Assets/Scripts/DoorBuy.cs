using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorBuy : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public int doorPrice = 1000;

    public GameObject managerGO;
    public UIManager uiManage;

    public PlayerController player;

    public GameObject pricePrompt;

    public Inputs input;

    public bool inRange = false;

    void Awake()
    {
        input = new Inputs();

        input.InGame.Interact.performed += _ => BuyDebris();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }


    void Start()
    {
        managerGO = GameObject.FindWithTag("GameController");
        uiManage = managerGO.GetComponent<UIManager>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = other.GetComponent<PlayerController>();

            inRange = true;

            pricePrompt.SetActive(true);
            pricePrompt.GetComponent<TextMeshProUGUI>().text = "Press F to clear debris, Cost: " + doorPrice;

        }
    }

    void BuyDebris()
    {
        if(inRange && player.playerPoints >= doorPrice)
        {
            foreach (GameObject spawnPoints in spawnPoints)
            {
                spawnPoints.gameObject.SetActive(true);
            }

            gameObject.SetActive(false);
            pricePrompt.SetActive(false);

            player.playerPoints -= doorPrice;
            uiManage.PointUpdate();
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
