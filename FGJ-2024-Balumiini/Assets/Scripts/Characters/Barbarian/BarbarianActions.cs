using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianActions : MonoBehaviour, ICombatActions
{
    [SerializeField]
    CombatStats combatStats;

    CharacterMovement myMovement;
    MeleeAttack primaryAttack;

    [SerializeField]
    ActionList actions;
    private void Start()
    {
        myMovement= GetComponent<CharacterMovement>();
        primaryAttack= GetComponentInChildren<MeleeAttack>();
    }

    public void PrimaryAction()
    {
        actions.Add(myMovement);
        actions.Add(primaryAttack);
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
