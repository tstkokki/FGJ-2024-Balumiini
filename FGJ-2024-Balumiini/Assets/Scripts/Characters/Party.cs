using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Party", menuName = "Custom/Party")]
public class Party : ScriptableObject
{
    public List<ICombatActions> Members = new();
    [SerializeField]
    IntVariable CurrentMember;

    public ICombatActions Current
    {
        get { return Members[CurrentMember.Value]; }
    }

    private void OnEnable()
    {
        Members.Clear();
    }

    private void OnDisable()
    {
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

        }
    }

    public void Remove(ICombatActions member)
    {
        if (Members.Contains(member))
        {
            Members.Remove(member);
        }
    }
}
