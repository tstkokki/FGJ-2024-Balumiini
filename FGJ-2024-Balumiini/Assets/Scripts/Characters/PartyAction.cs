using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyAction : MonoBehaviour
{
    [SerializeField]
    public Party Party;

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

    public void Levelup()
    {
        for (int i = 0; i < Party.Members.Count; i++)
        {
            if(i == 0)
            {
                Party.Members[i].Character.BaseStats.LevelUp();
            }
            else
            {
                Party.Members[i].Character.BaseStats.RefillHp();

            }
        }
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
            if (!Party.Current.HasActed && Party.Current.Character.BaseStats.Hp.Value > 0)
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
