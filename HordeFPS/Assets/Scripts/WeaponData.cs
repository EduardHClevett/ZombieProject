using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { Pistol, SMG, AssaultRifle, SniperRifle };
public enum ReloadType { Magazine, Insertion };
public enum FireMode { FullAuto, SemiAuto };

public class WeaponData : MonoBehaviour
{
    [Header("Gun Details")]
    public string weaponName;
    public WeaponType weaponType;
    public ReloadType reloadType;
    public FireMode fireMode;
    public float damage = 10f;
    public float headshotMultiplier = 1.5f;
    public float fireRate = 0.1f;
    public float range = 100f;
    public int magCapacity = 30;
    public int currentReserve = 120;
    public int startReserves = 120;
    public int maxReserve;
    public int extraMags = 10;
    public int currentMag;
    public int pellets = 1;
    public float spread;
    public float bulletVelocity = 5f;
    public bool hasLastFire = false;
    public float recoil = 0f;
    public float reloadTime = 1f;

    public int weaponCost = 1000;

    [SerializeField]
    private int shotsFired;

    [Header("Animation Details")]
    public Vector3 aimPos;
    public float aimSpeed = 8f;

    [Header("External References")]
    public GameObject player;
    public PlayerController playerControl;
    public CameraController camController;
    public Camera cam;
    public GameObject managerGO;
    public UIManager uiManage;
    public WeaponManager weaponManager;
    private Weapon weaponClass;
    public Inputs input;

    [Header("Internal References")]
    public Transform shootPoint;
    public Transform muzzlePoint;
    public ParticleSystem muzzleFlash;
    public AudioSource gunshotSfx;

    [Header("Upgrade Details")]
    public int weaponLevel = 1;

    private Animator anim;
    private float fireTimer;
    [SerializeField]
    private bool isReloading = false;
    private bool isEnabled = true;
    private Vector3 originalPos;
    [SerializeField]
    private Quaternion originalRot;

    [SerializeField]
    private float playerFOV;
    private float fovAdjust;

    private bool isAiming = false;
    bool isFiring = false;

    public bool IsEnabled
    {
        get { return isEnabled; }
        set { isEnabled = value; }
    }

    void Awake()
    {
        input = new Inputs();

        input.InGame.Shoot.started += _ => isFiring = true;
        input.InGame.Shoot.canceled += _ => isFiring = false;

        input.InGame.Reload.performed += _ => StartCoroutine(StartReload());

        input.InGame.Aim.performed += _ => StartADS();
        input.InGame.Aim.canceled += _ => StopADS();
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
        anim = GetComponent<Animator>();
        
        managerGO = GameObject.FindWithTag("GameController");
        uiManage = managerGO.GetComponent<UIManager>();

        camController = GetComponentInParent<CameraController>();

        weaponManager = GetComponentInParent<WeaponManager>();
        weaponClass = (Weapon) System.Enum.Parse(typeof(Weapon), weaponName);

        cam = Camera.main;

        playerFOV = cam.fieldOfView;
        fovAdjust = cam.fieldOfView - (cam.fieldOfView / 5);
        

        InitAmmo();

        originalPos = transform.localPosition;
        originalRot = transform.localRotation;

        if(!weaponManager.HasWeapon(weaponClass))
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {

        maxReserve = magCapacity * extraMags;

        shotsFired = magCapacity - currentMag;

        if(fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }

        anim.SetFloat("ReloadTime", reloadTime);

        if (currentMag == 0)
            StartCoroutine(StartReload());

        if(isAiming)
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fovAdjust, 0.5f);
        else
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, playerFOV, 0.5f);

        if(isFiring)
        {
            switch (fireMode)
            {
                case FireMode.FullAuto:
                    {
                        StartCoroutine(Fire());
                        break;
                    }
                case FireMode.SemiAuto:
                {
                        StartCoroutine(Fire());
                        break;
                }
            }
        }
    }

    void DrawHitRay()
    {
        Debug.DrawRay(shootPoint.position, CalculateSpread(spread, shootPoint), Color.green, 10f);
    }

    Vector3 CalculateSpread(float inaccuracy, Transform trans)
    {
        if (Input.GetButton("Fire2")) inaccuracy /= 2;

        return Vector3.Lerp(trans.TransformDirection(Vector3.forward * range), Random.onUnitSphere, inaccuracy);
    }

    IEnumerator DisableFire(float time = 0.3f)
    {
        isEnabled = false;
        isFiring = false;

        yield return new WaitForSeconds(time);
        isEnabled = true;

        yield break;
    }

    float GetWeaponDamage()
    {
        return weaponLevel * damage;
    }

    IEnumerator Fire(int repeats = 1)
    {
        while(true)
        {
            if (fireTimer < 1 / fireRate || !isEnabled || weaponManager.pauseFire || isReloading) yield break;

            for(int i = 0; i < repeats; i++)
            {
                if (currentMag <= 0)
                {
                    StartCoroutine(DisableFire());

                    shotsFired = magCapacity;
                    yield break;
                }
            }

            RaycastHit hit;

            if(gunshotSfx != null)
                gunshotSfx.PlayOneShot(gunshotSfx.clip);

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                ZombieAI_Nav zombie = hit.transform.GetComponent<ZombieAI_Nav>();

                if (zombie)
                {
                    zombie.TakeDamage(GetWeaponDamage(), this.gameObject);
                }
            }

            currentMag--;

            fireTimer = 0f;

            GiveRecoil();

            if(muzzleFlash != null)
                muzzleFlash.Play();

            if(fireMode != FireMode.FullAuto)
            {
                isFiring = false;
                yield break;
            }
        }
    }

    void StartADS()
    {
        isAiming = true;
        transform.localPosition = aimPos;
        uiManage.HideCrosshair(true);
    }
    void StopADS()
    {
        isAiming = false;
        transform.localPosition = originalPos;
        uiManage.HideCrosshair(false);
    }

    IEnumerator StartReload()
    {
        if (isReloading || currentMag >= magCapacity || currentReserve <= 0)
        {
            yield break;
        }

        isReloading = true;

        anim.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);

        if((currentReserve < magCapacity) && ((currentMag + currentReserve) <= magCapacity))
        {
            currentMag += currentReserve;
            currentReserve = 0;
        }
        else
        {
            currentMag = magCapacity;
            currentReserve -= shotsFired;
        }

        isReloading = false;
        anim.SetBool("Reloading", false);
        shotsFired = 0;
    }

    public void DrawObj()
    {
        StartCoroutine(PrepareWeapon());
    }

    public void InitAmmo()
    {
        currentReserve = startReserves;
        currentMag = magCapacity;

        weaponLevel = 1;
    }

    IEnumerator PrepareWeapon()
    {
        yield return new WaitForEndOfFrame();

        isEnabled = true;

        yield break;
    }

    public void UnloadObj()
    {
        isReloading = false;
        transform.localRotation = originalRot;
        isEnabled = false;
        anim.SetBool("Reloading", false);

        gameObject.SetActive(false);
    }

    void GiveRecoil()
    {
        if(recoil <= 0)
        {
            recoil = 0;
        }

        camController.StartRecoil(recoil);
    }
}
