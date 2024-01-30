using Balumiini.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReceiver : MonoBehaviour, IInputReceiver
{

    PartyAction party;
    [SerializeField]
    GameEvent ExecuteTurn;

    [SerializeField]
    BattleRecord BattleRecord;
    [SerializeField]
    BattleState PlayerPhase;
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
        Debug.unityLogger.logEnabled = false;
#endif
        party = GetComponent<PartyAction>();
    }
    public void OnPrimary(InputAction.CallbackContext ctx)
    {
        if (PressedDuringPlayerPhase(ctx))
        {
            Debug.Log("Primary pressed");
            party.AddToTurn();
            if (party.AllActed())
                ExecuteTurn.Raise();
        }
    }

    private bool PressedDuringPlayerPhase(InputAction.CallbackContext ctx)
    {
        return BattleRecord.CurrentState == PlayerPhase && ctx.PressPerformed();
    }

    public void OnSecondary(InputAction.CallbackContext ctx)
    {
        if (PressedDuringPlayerPhase(ctx))
        {
            Debug.Log("Secondary pressed");
        }
    }

    public void OnTertiary(InputAction.CallbackContext ctx)
    {
        if (PressedDuringPlayerPhase(ctx))
        {
            party.AutoAttack();
            ExecuteTurn.Raise();
        }
    }

    public void OnBack(InputAction.CallbackContext ctx)
    {
        if (PressedDuringPlayerPhase(ctx))
        {
            Debug.Log("Back pressed");
        }
    }

    public void OnHorizontal(InputAction.CallbackContext ctx)
    {
        var value = ctx.ReadValue<float>();
        if (PressedInADirection(ref ctx, value))
        {
            Debug.Log($"Horizontal {ctx.ReadValue<float>()} pressed");
            if (value == 1)
                party.SelectPrevious();
            else
                party.SelectNext();
        }
    }

    private static bool PressedInADirection(ref InputAction.CallbackContext ctx, float value)
    {
        return ctx.performed && (value == -1 || value == 1);
    }

    public void OnVertical(InputAction.CallbackContext ctx)
    {
        var value = ctx.ReadValue<float>();
        if (PressedInADirection(ref ctx, value))
        {
            Debug.Log($"Vertical {ctx.ReadValue<float>()} pressed");
        }
    }


    public void OnParty1(InputAction.CallbackContext ctx)
    {
        if (PressedDuringPlayerPhase(ctx))
        {
            Debug.Log("Party1 pressed");
        }
    }

    public void OnParty2(InputAction.CallbackContext ctx)
    {
        if (PressedDuringPlayerPhase(ctx))
        {
            Debug.Log("Party 2 pressed");
        }
    }

    public void OnParty3(InputAction.CallbackContext ctx)
    {
        if (PressedDuringPlayerPhase(ctx))
        {
            Debug.Log("Party 3 pressed");
        }
    }

    public void OnParty4(InputAction.CallbackContext ctx)
    {
        if (PressedDuringPlayerPhase(ctx))
        {
            Debug.Log("Party 4 pressed");
        }
    }

    public void OnParty5(InputAction.CallbackContext ctx)
    {
        if (PressedDuringPlayerPhase(ctx))
        {
            Debug.Log("Party 5 pressed");
        }
    }

    public void OnParty6(InputAction.CallbackContext ctx)
    {
        if (PressedDuringPlayerPhase(ctx))
        {
            Debug.Log("Party 6 pressed");
        }
    }



}
