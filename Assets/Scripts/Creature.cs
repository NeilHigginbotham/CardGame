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
    // not using summoning sickness for now
    // public bool summoningSickness = true;
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

    public void StartAttack()
    {
        /*
        // If not summoning sick then the attack will commence.
        if (!summoningSickness)
        {
            isAttacking = true;
        }
        */
        
        isAttacking = true;
    }
}