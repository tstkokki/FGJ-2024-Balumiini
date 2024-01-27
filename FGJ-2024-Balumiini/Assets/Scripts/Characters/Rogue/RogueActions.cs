using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueActions : MonoBehaviour, ICombatActions
{
    [SerializeField]
    CombatStats combatStats;

    CharacterMovement myMovement;
    MeleeAttack primaryAttack;
    Return returnBack;

    [SerializeField]
    ActionList actions;


    private void Start()
    {
        myMovement = GetComponent<CharacterMovement>();
        primaryAttack = GetComponentInChildren<MeleeAttack>();
        returnBack = GetComponent<Return>();
    }

    public void PrimaryAction()
    {
        actions.Add(myMovement);
        actions.Add(primaryAttack);
        actions.Add(returnBack);
    }
    public void SecondaryAction()
    {
        throw new System.NotImplementedException();
    }

    public void TertiaryAction()
    {
        throw new System.NotImplementedException();
    }

}
