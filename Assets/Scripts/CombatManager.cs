using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void DeclareAttack(Creature attackingCreature)
    {
        // Logic to handle when a creature is declared as an attacker
        attackingCreature.isAttacking = true;
    }

    public void DeclareBlock(Creature attackingCreature, Creature blockingCreature)
    {
        // Logic to handle when a creature is declared as a blocker
        attackingCreature.isBlocking = true;

        // Calculate combat damage and resolve it
        ResolveCombat(attackingCreature, blockingCreature);
    }

    private void ResolveCombat(Creature attacker, Creature blocker)
    {
        // Determine combat damage
        int damageToAttacker = Mathf.Max(0, blocker.power - attacker.toughness);
        int damageToBlocker = Mathf.Max(0, attacker.power - blocker.toughness);

        // Apply damage to creatures
        attacker.TakeDamage(damageToAttacker);
        blocker.TakeDamage(damageToBlocker);

        // Reset combat state
        attacker.isAttacking = false;
        attacker.isBlocking = false;
        blocker.isBlocking = false;
    }
}
