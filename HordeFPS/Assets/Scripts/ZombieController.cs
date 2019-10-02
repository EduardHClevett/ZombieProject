using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public int zombieHealth;
    public float moveSpeed;
    public int damage;

    public GameObject player;

    public Animator anim;

    public GameManager gameManager;

    public bool isHit = false;

    void Start()
    {
        anim = GetComponent<Animator>();

        zombieHealth = 100 * gameManager.round;

        player = GameObject.FindWithTag("Player");
    }

    void Update()
    { 
        HealthUpdate();
        Chase();
    }

    void HealthUpdate()
    {
        if(isHit)
        {
            zombieHealth = zombieHealth - damage;
        }
    }

    void Chase()
    {
        if(gameManager.round < 7)
        {
            moveSpeed = 0.5f;
        }
        else
        {
            moveSpeed = 1;
        }

        anim.SetFloat("moveSpeed", moveSpeed);

        transform.LookAt(player.transform.position);

        transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}
