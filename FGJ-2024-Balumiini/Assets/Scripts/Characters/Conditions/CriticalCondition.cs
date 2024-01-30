using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Critical", menuName = "Custom/Combat/Critical")]
public class CriticalCondition : BaseCondition
{
    public StatusType Debuff;
    public override int TrueDamage(CombatStats attacker, int dmg, CombatStats defender)
    {
        if(defender.StatusConditions.Count > 0 
            || defender.StatusConditions
            .Any(s => s.Type != null && s.Type == Debuff)) 
        {
            return dmg;
        }
        return attacker.BaseStats.LevelledAtk;
    }
}
