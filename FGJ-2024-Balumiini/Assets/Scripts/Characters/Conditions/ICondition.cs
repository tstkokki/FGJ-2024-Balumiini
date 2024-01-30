using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICondition
{
    int TrueDamage(CombatStats attacker, int dmg, CombatStats defender);
}
