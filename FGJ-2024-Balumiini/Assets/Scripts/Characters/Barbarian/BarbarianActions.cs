using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianActions : MonoBehaviour, ICombatActions, ISoundEffect
{
    [SerializeField]
    CombatStats combatStats;

    CharacterMovement myMovement;
    MeleeAttack primaryAttack;
    Return returnBack;

    [SerializeField]
    ParticleSystem meow;

    [SerializeField]
    BooleanVariable hasActed;
    public bool HasActed { get => hasActed.Value; set => hasActed.Value = value; }

    public CombatStats Character => combatStats;

    IntVariable CurrentMember { get; set; }

    [SerializeField]
    SoundPlayer player;

    [SerializeField]
    SoundClip effect;
    public SoundPlayer Player { get => player; }
    public SoundClip Effect { get => effect; }

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
        PlayParticle();
        PlayEffect();

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

    public void PlayEffect()
    {
        if (player != null && effect != null)
            player.PlayOneShot(effect);
    }

    public void PlayParticle()
    {
        if (meow != null)
        {

            meow.Clear();
            meow.Stop();
            meow.Play();
        }
    }
}
