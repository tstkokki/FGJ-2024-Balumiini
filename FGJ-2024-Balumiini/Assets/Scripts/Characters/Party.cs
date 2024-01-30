using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Party", menuName = "Custom/Party")]
public class Party : ScriptableObject
{
    public List<ICombatActions> Members = new();
    /// <summary>
    /// Index of current party member
    /// </summary>
    public IntVariable CurrentMember;

    public void ResetLevels()
    {
        if (Members.FirstOrDefault() != null)
            Members.FirstOrDefault().Character.BaseStats.Level.Variable.Value = 1;
    }

    public void Refresh()
    {
        CurrentMember.Value = 0;
        foreach (var member in Members)
        {
            member.HasActed = false;
        }
    }

    /// <summary>
    /// Gets the current party member
    /// </summary>
    public ICombatActions Current
    {
        get
        {
            if (Members.Count == 0) return null;
            if (CurrentMember.Value >= Members.Count)
                return null;
            
            var current = Members[CurrentMember.Value];
            if (current == null || !current.Character.IsAlive)
            {
                for (int i = 0; i < Members.Count; i++)
                {
                    current= Members[i];
                    if (current.Character.IsAlive)
                        break;
                }
            }
            return current;
        }
    }

    private void OnEnable()
    {
        CurrentMember.Value = 0;
        Members.Clear();
    }

    private void OnDisable()
    {
        CurrentMember.Value = 0;
        Members.Clear();
    }

    public void Next()
    {
        CurrentMember.Value = (CurrentMember.Value + 1) % Members.Count;
    }
    public void Previous()
    {
        CurrentMember.Value = (CurrentMember.Value - 1 + Members.Count) % Members.Count;
    }

    public void Add(ICombatActions member)
    {
        if (!Members.Contains(member))
        {
            Members.Add(member);
            member.SetCurrentMember(CurrentMember);
            Members = Members.OrderBy(p => p.Character.BaseStats.PartySlot).ToList();
        }
    }

    public void Remove(ICombatActions member)
    {
        if (Members.Contains(member))
        {
            Members.Remove(member);
            Members = Members.OrderBy(p => p.Character.BaseStats.PartySlot).ToList();
        }
    }
}
