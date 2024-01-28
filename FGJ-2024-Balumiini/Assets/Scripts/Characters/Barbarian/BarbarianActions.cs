using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianActions : MonoBehaviour, ICombatActions
{
    [SerializeField]
    CombatStats combatStats;

    CharacterMovement myMovement;
    MeleeAttack primaryAttack;
    Return returnBack;

    [SerializeField]
    BooleanVariable hasActed;
    public bool HasActed { get => hasActed.Value; set => hasActed.Value = value; }

    public CombatStats Character => combatStats;

    IntVariable CurrentMember { get; set; }

    private void Start()
    {
        myMovement = GetComponent<CharacterMovement>();
        primaryAttack = GetComponentInChildren<MeleeAttack>();
        returnBack = GetComponent<Return>();
        primaryAttack.Me = combatStats;
        myMovement.Me = this;
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

    public void SetCurrentMember(IntVariable currentMember)
    {
        CurrentMember = currentMember;
    }
}
