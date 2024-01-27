using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Combat Stats", menuName = "Custom/Stats/Combat")]
public class CombatStats : ScriptableObject
{
    [SerializeField]
    Stats BaseStats;

    [Space]
    [Header("Actions")]
    [SerializeField]
    FloatReference PrimaryActionMultiplier;

    [SerializeField]
    FloatReference SecondaryActionMultiplier;

    public int PrimaryAttack()
    {
        return Mathf.FloorToInt(PrimaryActionMultiplier.Value * BaseStats.Atk.Value);
    }

    public int SecondaryAttack()
    {
        return Mathf.FloorToInt(SecondaryActionMultiplier.Value * BaseStats.Atk.Value);
    }
}
