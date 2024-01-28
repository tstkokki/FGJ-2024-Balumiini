using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatActions 
{
    public bool HasActed { get; set; }
    public CombatStats Character { get; }
    void SetCurrentMember(IntVariable currentMember);
    void PrimaryAction(ActionList actions);
    void SecondaryAction(ActionList actions);
    void TertiaryAction(ActionList actions);
}
