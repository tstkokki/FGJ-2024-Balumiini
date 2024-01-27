using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Party", menuName = "Custom/Party")]
public class Party : ScriptableObject
{
    public List<ICombatActions> members = new();
    int currentMember = 0;

    private void OnEnable()
    {
        members.Clear();
    }

    private void OnDisable()
    {
        members.Clear();
    }

    public void Next()
    {
        currentMember = (currentMember + 1) % members.Count;
    }
    public void Previous()
    {
        currentMember = (currentMember - 1 + members.Count) % members.Count;
    }

    public void Add(ICombatActions member)
    {
        if (!members.Contains(member))
        {
            members.Add(member);

        }
    }

    public void Remove(ICombatActions member)
    {
        if (members.Contains(member))
        {
            members.Remove(member);
        }
    }
}
