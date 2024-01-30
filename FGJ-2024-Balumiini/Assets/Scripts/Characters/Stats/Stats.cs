using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName = "Custom/Stats/Base Stats")]
public class Stats : ScriptableObject
{
    public string Name;
    public IntReference Level;
    public Sprite Icon;
    public int PartySlot;
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
        Hp.Value = Mathf.Min(Hp.Value + amount, LevelledMaxHp);
    }
    public void TakeDamage(int amount)
    {
        Hp.Value = Mathf.Max(Hp.Value - amount, 0);

    }

    public int LevelledMaxHp { get => MaxHp.Value + (Level.Value*HpGrowth.Value); }
    public int LevelledAtk { get => Atk.Value + (Level.Value*AtkGrowth.Value); }
    public int LevelledDef { get => Def.Value + (Level.Value*DefGrowth.Value); }


    public void LevelUp()
    {
        Level.Variable.Value += 1;
        RefillHp();
        //MaxHp.Variable.Value += HpGrowth.Value;
        //Atk.Variable.Value += AtkGrowth.Value;
        //Def.Variable.Value += DefGrowth.Value;
    }

    public void RefillHp()
    {
        Hp.Value += (HpGrowth.Value*Level.Value);
        Hp.Value = Mathf.Min(LevelledMaxHp, Hp.Value);
    }

    public void OnReset()
    {
        
        if (Hp != null)
            Hp.Value = LevelledMaxHp;
        //if (MaxHp != null)
        //    MaxHp.Variable.Value = MaxHp.ConstantValue;
        //if (Atk != null)
        //    Atk.Variable.Value = Atk.ConstantValue;
        //if (Def != null)
        //    Def.Variable.Value = Def.ConstantValue;
    }

    private void OnDisable()
    {
        OnReset();
    }

    private void OnEnable()
    {
        OnReset();
    }
}
