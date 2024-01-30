using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inflict Debuff", menuName = "Custom/Combat/Inflict Debuff")]
public class InflictDebuff : BaseCondition
{
    public StatusEffect Debuff;
    public override int TrueDamage(CombatStats attacker, int dmg, CombatStats defender)
    {
        defender.InflictStatus(Debuff);
        return dmg;
    }
}
