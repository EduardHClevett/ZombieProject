using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon
{
    None,
    Glock,
    Revolver,
    M4A1,
    AKM,
    MP5,
    Skorpion,
    MVR3
}

public class WeaponManager : MonoBehaviour
{
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;

    public Weapon currentWeapon;
    public Weapon startWeapon;

    public GameObject primaryGO;
    public GameObject secondaryGO;

    public GameObject currentWeaponGO;

    public bool pauseFire = false;

    public Inputs input;

    void Awake()
    {
        input = new Inputs();

        input.InGame.SwitchWeapon.started += _ => SwitchWeapon();
    }

    void Start()
    {
        primaryWeapon = Weapon.None;
        secondaryWeapon = startWeapon;

        currentWeapon = secondaryWeapon;

        primaryGO = null;
        secondaryGO = transform.Find(secondaryWeapon.ToString()).gameObject;

        currentWeaponGO = secondaryGO;

        StartCoroutine(Init());
    }

    void OnEnable()
    {
        input.Enable();
    }
    void OnDisable()
    {
        input.Disable();
    }

    IEnumerator Init()
    {
        currentWeaponGO.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        currentWeaponGO.GetComponent<WeaponData>().DrawObj();

        yield break;
    }

    public bool HasWeapon(Weapon weapon)
    {
        if (primaryWeapon == weapon || secondaryWeapon == weapon) return true;

        return false;
    }

    void SwitchWeapon()
    {
        if (primaryWeapon != Weapon.None && currentWeapon != primaryWeapon)
        {
            currentWeaponGO.GetComponent<WeaponData>().UnloadObj();

            currentWeapon = primaryWeapon;
            currentWeaponGO = primaryGO;

            currentWeaponGO.SetActive(true);
            currentWeaponGO.GetComponent<WeaponData>().DrawObj();
        }
        else if (secondaryWeapon != Weapon.None && currentWeapon != secondaryWeapon)
        {
            currentWeaponGO.GetComponent<WeaponData>().UnloadObj();

            currentWeapon = secondaryWeapon;
            currentWeaponGO = secondaryGO;

            currentWeaponGO.SetActive(true);
            currentWeaponGO.GetComponent<WeaponData>().DrawObj();
        }
    }
}
