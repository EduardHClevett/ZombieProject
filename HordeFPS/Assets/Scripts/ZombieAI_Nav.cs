using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class ZombieAI_Nav : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public GameManager manager;
    public UIManager uiManage;
    public Animator anim;

    public float health = 50f;
    public float healthToRound = 20;
    public float stopPoint;

    public int jogRound;
    public int sprintRound;

    private int attacking = 0;

    public NavMeshAgent zombieAgent;

    public AudioSource idleSource;
    public AudioSource attackSource;
    
    void Start()
    {
        anim = GetComponent<Animator>();

        gameManager = GameObject.FindWithTag("GameController");
        manager = gameManager.GetComponent<GameManager>();
        uiManage = gameManager.GetComponent<UIManager>();

        health = healthToRound * manager.round;
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player");

        try
        {
            zombieAgent.SetDestination(player.transform.position);
        }
        catch
        {
            Debug.Log("Player object is null!");
        }
        
        RoundSpeedCheck();

        anim.SetFloat("moveSpeed", zombieAgent.speed);

        if(zombieAgent.remainingDistance < stopPoint)
        {
            zombieAgent.speed = 0f;
            anim.SetBool("Attacking", true);
            attackSource.Play();
            attacking = 1;
        }
        else
        {
            anim.SetBool("Attacking", false);
            RoundSpeedCheck();
            attacking = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (attacking == 1)
            {
                Debug.Log("Player hit!");

                other.GetComponent<PlayerController>().health -= 50;
            }
        }
    }

    public void RoundSpeedCheck()
    {
        if (manager.round < jogRound)
        {
            zombieAgent.speed = 0.5f;
        }
        else if (manager.round >= jogRound && manager.round < sprintRound)
        {
            zombieAgent.speed = 1.5f;
        }
        else if(manager.round >= sprintRound)
        {
            zombieAgent.speed = 2.75f;
        }
    }

    public void TakeDamage(float amount, GameObject attacker)
    {
        health -= amount;

        PlayerController atk = attacker.GetComponentInParent<PlayerController>();
        if (atk != null)
        {
            atk.playerPoints += 10;
        }

        uiManage.PointUpdate();

        if(health <= 0)
        {
            Destroy(gameObject);

            manager.zombiesKilledThisRound++;
            manager.zombiesSpawned--;

            if(atk != null)
            { atk.playerPoints += 60; }

            uiManage.PointUpdate();
            uiManage.ZombieUpdate();
            manager.ZombieManager();
        }
    }
}
