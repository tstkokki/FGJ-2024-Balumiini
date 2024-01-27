using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyAction : MonoBehaviour
{
    [SerializeField]
    Party Party;

    [SerializeField]
    ActionList Actions;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ResetTurn()
    {
        foreach (var member in Party.Members)
        {
            member.HasActed = false;
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
