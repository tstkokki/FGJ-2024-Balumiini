using UnityEngine;

[CreateAssetMenu(fileName = "New Heal", menuName = "Custom/Combat/Heal")]
public class HealAction : BaseCondition
{
    public override int TrueDamage(CombatStats attacker, int dmg, CombatStats defender)
    {
        Debug.Log($"Defender {defender.BaseStats.Name} HP {defender.BaseStats.Hp.Value}");
        defender.BaseStats.Heal(attacker.PrimaryAttack());
        Debug.Log($"Healed Defender {defender.BaseStats.Name} HP {defender.BaseStats.Hp.Value}");

        return 0;
    }
}
