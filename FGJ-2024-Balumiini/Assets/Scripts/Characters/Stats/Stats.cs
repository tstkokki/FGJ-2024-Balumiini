using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName = "Custom/Stats/Base Stats")]
public class Stats : ScriptableObject
{
    public string Name;
    public IntReference Level;
    [Space]
    public IntVariable Hp;
    public IntReference MaxHp;
    [Space]
    public IntReference Atk;
    public IntReference Def;
    [Space]
    [Header("Stat Growths")]
    public IntReference HpGrowth;
    public IntReference AtkGrowth;
    public IntReference DefGrowth;

    public void Heal(int amount)
    {
        Hp.Value = Mathf.Min(Hp.Value + amount, MaxHp.Value);
    }
    public void TakeDamage(int amount)
    {
        Hp.Value = Mathf.Max(Hp.Value - amount, 0);

    }

    public void LevelUp()
    {
        Level.Variable.Value += 1;
        Hp.Value += HpGrowth.Value;
        MaxHp.Variable.Value += HpGrowth.Value;
        Atk.Variable.Value += AtkGrowth.Value;
        Def.Variable.Value += DefGrowth.Value;
    }

    private void Reset()
    {
        Level.Variable.Value = Level.ConstantValue;
        Hp.Value = MaxHp.ConstantValue;
        MaxHp.Variable.Value= MaxHp.ConstantValue;

        Atk.Variable.Value = Atk.ConstantValue;
        Def.Variable.Value = Def.ConstantValue;
    }

    private void OnDisable()
    {
        Reset();
    }

    private void OnEnable()
    {
        Reset();
    }
}
