using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        ZombieAI_Nav zombie = other.gameObject.GetComponent<ZombieAI_Nav>();

        if (zombie)
        {
            zombie.TakeDamage(90000, null);
        }
    }
}
