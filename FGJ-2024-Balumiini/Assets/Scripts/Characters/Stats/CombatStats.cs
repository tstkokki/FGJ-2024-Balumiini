using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Combat Stats", menuName = "Custom/Stats/Combat")]
public class CombatStats : ScriptableObject
{
    
    public Stats BaseStats;

    [Space]
    [Header("Actions")]
    [SerializeField]
    FloatReference PrimaryActionMultiplier;

    [SerializeField]
    FloatReference SecondaryActionMultiplier;

    public List<IStatus> StatusConditions = new();
    public List<BaseCondition> AttackConditions = new();
    public int PrimaryAttack()
    {
        var atk = BaseStats.LevelledAtk;
        if(StatusConditions.Count > 0)
        {
            for (int i = 0; i < StatusConditions.Count; i++)
            {
                atk += StatusConditions[i].AtkEffect;
            }
            atk = atk < 0 ? 0 : atk;
        }
        return Mathf.FloorToInt(PrimaryActionMultiplier.Value * atk);
    }

    public int TotalDefense()
    {
        var def = BaseStats.LevelledDef;
        if (StatusConditions.Count > 0)
        {
            for (int i = 0; i < StatusConditions.Count; i++)
            {
                def += StatusConditions[i].DefEffect;
            }
            def = def < 0 ? 0 : def;
        }
        return def;
    }

    public int SecondaryAttack()
    {
        return Mathf.FloorToInt(SecondaryActionMultiplier.Value * BaseStats.LevelledAtk);
    }

    public bool IsAlive
    {
        get => BaseStats.Hp.Value> 0;
    }

    public void InflictStatus(StatusEffect status)
    {
        if(!StatusConditions.Contains(status))
            StatusConditions.Add(status);
    }

    public void ClearStatuses()
    {
        StatusConditions.Clear();
    }
}
