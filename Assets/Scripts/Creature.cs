using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public int power;
    public int toughness;
    public bool isAttacking;
    public bool isBlocking;
    public bool playerOwned;

    public void TakeDamage(int damage)
    {
        // Creatures take damage
        toughness -= damage;
        if (toughness <= 0)
        {
            // Change to put the creature in the graveyard
            Destroy(gameObject);
        }
    }
}