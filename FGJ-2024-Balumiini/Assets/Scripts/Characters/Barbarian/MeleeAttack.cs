using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, ITurnAction
{
    public bool IsDone { get; set; }

    Animator animator;
    public string animationName = "BarbAttack";

    public DealDamage dealDamage;

    [SerializeField]
    Party TargetParty;

    public CombatStats Me;
    public void Execute()
    {
        IsDone = false;
        animator.Play(animationName);
    }

    public void Hurt()
    {
        if(dealDamage== null || TargetParty == null || TargetParty.Current == null)
        {
            return;
        }
        dealDamage.HandlePrimary(Me, TargetParty.Current.Character);
    }

    public void Finished()
    {
        IsDone = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

}
