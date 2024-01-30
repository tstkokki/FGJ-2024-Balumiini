using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Heal", menuName = "Custom/Combat/Heal")]
public class HealAction : BaseCondition
{
    public override int TrueDamage(CombatStats attacker, int dmg, CombatStats defender)
    {
        defender.BaseStats.Heal(attacker.PrimaryAttack());

        return 0;
    }
}
