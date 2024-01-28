using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyAction : MonoBehaviour
{
    [SerializeField]
    Party Party;

    [SerializeField]
    ActionList Actions;

    [SerializeField]
    GameEvent PartyWiped;

    private void Awake()
    {
        Party.Refresh();
    }

    public void ResetTurn()
    {
        Party.Refresh();
    }

    public bool AllActed()
    {
        for (int i = 0; i < Party.Members.Count; i++)
        {
            if (!Party.Members[i].HasActed)
            {
                return false;
            }
        }
        return true;
    }

    public void CheckPartyHp()
    {
        foreach (var member in Party.Members)
        {
            if (member.Character.BaseStats.Hp.Value > 0)
                return;
        }
        if (PartyWiped != null)
            PartyWiped.Raise();
    }

    public void AddToTurn()
    {
        if (Party != null)
        {
            if (!Party.Current.HasActed)
            {
                Party.Current.PrimaryAction(Actions);
                SelectNext();
            }
        }
    }

    public void SelectPrevious()
    {
        Party.Previous();
    }

    public void SelectNext()
    {
        Party.Next();
    }



}
