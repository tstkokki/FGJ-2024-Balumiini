using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Dealer", menuName = "Custom/Combat/Deal Damage")]
public class DealDamage : ScriptableObject, ICombatRound
{
    [SerializeField]
    GameEvent UpdateUI;
    public void HandlePrimary(CombatStats attacker, CombatStats defender)
    {
        var dmg = Mathf.Max(0, attacker.PrimaryAttack() - defender.BaseStats.LevelledDef);
        defender.BaseStats.TakeDamage(dmg);
        UpdateUI.Raise();
    }

    public void HandleSecondary(CombatStats attacker, CombatStats defender)
    {
        var dmg = Mathf.Max(0, attacker.SecondaryAttack() - defender.BaseStats.LevelledDef);
        defender.BaseStats.TakeDamage(dmg);
        UpdateUI.Raise();
        
    }

}
