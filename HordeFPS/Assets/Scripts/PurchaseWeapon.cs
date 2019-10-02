using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchaseWeapon : MonoBehaviour
{
    public Weapon weapon;
    public GameObject weaponGO;

    public GameObject managerGO;
    public UIManager uiManage;

    public GameObject weaponManagerGO;
    public WeaponManager weaponManager;

    public GameObject pricePrompt;

    private int weaponPrice;

    public PlayerController player;

    public Inputs input;

    public bool inRange = false;

    void Awake()
    {
        input = new Inputs();

        input.InGame.Interact.performed += _ => BuyWeapon();

        weaponGO = GameObject.Find(weapon.ToString());
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

        weaponManager = weaponManagerGO.GetComponent<WeaponManager>();

        weaponPrice = weaponGO.GetComponent<WeaponData>().weaponCost;
    }

    void BuyWeapon()
    {
        if(!weaponManager.HasWeapon(weapon) && player.playerPoints >= weaponPrice && inRange)
        {
            if(weaponManager.primaryWeapon == Weapon.None)
            {
                weaponManager.currentWeaponGO.GetComponent<WeaponData>().UnloadObj();

                weaponManager.primaryWeapon = weapon;
                weaponManager.primaryGO = weaponGO;

                weaponManager.currentWeapon = weapon;
                weaponManager.currentWeaponGO = weaponGO;

                weaponManager.currentWeaponGO.GetComponent<WeaponData>().InitAmmo();
                weaponManager.currentWeaponGO.SetActive(true);
                weaponManager.currentWeaponGO.GetComponent<WeaponData>().DrawObj();

                player.playerPoints -= weaponPrice;
                uiManage.PointUpdate();
            }
            else if(weaponManager.currentWeapon == weaponManager.secondaryWeapon)
            {
                weaponManager.currentWeaponGO.GetComponent<WeaponData>().UnloadObj();

                weaponManager.secondaryWeapon = weapon;
                weaponManager.secondaryGO = weaponGO;

                weaponManager.currentWeapon = weapon;
                weaponManager.currentWeaponGO = weaponGO;

                weaponManager.currentWeaponGO.GetComponent<WeaponData>().InitAmmo();
                weaponManager.currentWeaponGO.SetActive(true);
                weaponManager.currentWeaponGO.GetComponent<WeaponData>().DrawObj();

                player.playerPoints -= weaponPrice;
                uiManage.PointUpdate();
            }
            else if(weaponManager.currentWeapon == weaponManager.primaryWeapon)
            {
                weaponManager.currentWeaponGO.GetComponent<WeaponData>().UnloadObj();

                weaponManager.primaryWeapon = weapon;
                weaponManager.primaryGO = weaponGO;

                weaponManager.currentWeapon = weapon;
                weaponManager.currentWeaponGO = weaponGO;

                weaponManager.currentWeaponGO.GetComponent<WeaponData>().InitAmmo();
                weaponManager.currentWeaponGO.SetActive(true);
                weaponManager.currentWeaponGO.GetComponent<WeaponData>().DrawObj();

                player.playerPoints -= weaponPrice;
                uiManage.PointUpdate();
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player" && !weaponManager.HasWeapon(weapon))
        {
            player = collider.GetComponent<PlayerController>();

            inRange = true;

            pricePrompt.SetActive(true);
            pricePrompt.GetComponent<TextMeshProUGUI>().text = "Press F to buy " + weapon + ", Cost: " + weaponPrice;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            player = null;

            pricePrompt.SetActive(false);
            inRange = false;
        }
    }
}
