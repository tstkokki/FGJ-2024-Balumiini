using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseCondition : ScriptableObject, ICondition
{
    public abstract int TrueDamage(CombatStats attacker, int dmg, CombatStats defender);
}
