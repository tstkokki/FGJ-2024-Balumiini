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

    public bool HasActed { get; set ; }

    private void Start()
    {
        myMovement = GetComponent<CharacterMovement>();
        primaryAttack = GetComponentInChildren<MeleeAttack>();
        returnBack = GetComponent<Return>();
    }

    public void PrimaryAction(ActionList actions)
    {
        actions.Add(myMovement);
        actions.Add(primaryAttack);
        actions.Add(returnBack);
        HasActed = true;
    }
    public void SecondaryAction(ActionList actions)
    {
        throw new System.NotImplementedException();
    }

    public void TertiaryAction(ActionList actions)
    {
        throw new System.NotImplementedException();
    }

}
