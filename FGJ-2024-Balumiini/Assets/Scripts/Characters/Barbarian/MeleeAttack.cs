using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, ITurnAction
{
    public bool IsDone { get; set; }

    Animator animator;
    public string animationName = "BarbAttack";
    public void Execute()
    {
        IsDone = false;
        animator.Play(animationName);
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
