using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatRound
{
    void HandlePrimary(CombatStats attacker, CombatStats defender);
    void HandleSecondary(CombatStats attacker, CombatStats defender);
}
