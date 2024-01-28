using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, ITurnAction, ISoundEffect
{
    public bool IsDone { get; set; }

    [SerializeField]
    SoundPlayer player;

    [SerializeField]
    SoundClip effect;
    public SoundPlayer Player { get => player; }
    public SoundClip Effect { get => effect; }

    Animator animator;
    public string animationName = "BarbAttack";

    public DealDamage dealDamage;

    [SerializeField]
    Party TargetParty;

    public CombatStats Me;

    [SerializeField]
    GameEvent CheckPartyWipe;

    public GameEvent AttackEffect;

    public ParticleSystem defaultEffect;

    public void Execute()
    {
        IsDone = false;
        animator.Play(animationName);
    }

    public void PlayEffect()
    {
        if(AttackEffect!= null)
        {
            AttackEffect.Raise();
        }
        if(defaultEffect!= null)
        {
            defaultEffect.Play();
        }
        if (player != null && effect != null)
            player.PlayOneShot(effect);
    }

    public void Hurt()
    {
        
        if (dealDamage == null || TargetParty == null || TargetParty.Current == null)
        {
            return;
        }
        dealDamage.HandlePrimary(Me, TargetParty.Current.Character);
        CheckPartyWipe.Raise();
    }

    public void Finished()
    {
        IsDone = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

}
