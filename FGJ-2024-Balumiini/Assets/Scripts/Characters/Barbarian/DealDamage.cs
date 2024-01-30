using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Dealer", menuName = "Custom/Combat/Deal Damage")]
public class DealDamage : ScriptableObject, ICombatRound
{
    [SerializeField]
    GameEvent UpdateUI;

    [SerializeField]
    GameEvent CheckPartyWipe;
    public void HandlePrimary(CombatStats attacker, CombatStats defender)
    {
        var atk = attacker.PrimaryAttack();
        if (attacker.AttackConditions.Count > 0)
        {
            for (int i = 0; i < attacker.AttackConditions.Count; i++)
            {
                atk = attacker.AttackConditions[i].TrueDamage(attacker, atk, defender);
            }
        }
        var def = defender.TotalDefense();

        var dmg = Mathf.Max(1, atk - def);
        defender.BaseStats.TakeDamage(dmg);
        UpdateUI.Raise();
        CheckPartyWipe.Raise();
    }

    public void HandleSecondary(CombatStats attacker, CombatStats defender)
    {
        var dmg = Mathf.Max(0, attacker.SecondaryAttack() - defender.BaseStats.LevelledDef);
        defender.BaseStats.TakeDamage(dmg);
        UpdateUI.Raise();
        CheckPartyWipe.Raise();

    }

}
