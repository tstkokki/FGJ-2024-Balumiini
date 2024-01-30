using System.Collections;
using UnityEngine;

public class TurnTracker : MonoBehaviour
{

    [SerializeField]
    ActionList actions;

    [SerializeField]
    GameEvent NewTurn;
    
    [SerializeField]
    GameEvent RefreshParty;

    [SerializeField]
    GameEvent UpdateUI;

    [Space]
    [SerializeField]
    BattleRecord BattleRecord;

    [SerializeField]
    BattleState PlayerPhase;

    [SerializeField]
    BattleState EnemyPhase;

    [SerializeField]
    BattleState EndOfBattle;

    private void Awake()
    {
        BattleRecord.CurrentState = PlayerPhase;
    }

    public void ExecuteTurn()
    {
        
        StartCoroutine(ExecuteActions());
    }

   

    IEnumerator ExecuteActions()
    {
        yield return new WaitForEndOfFrame();
        RefreshParty.Raise();
        // Assume actions are stored in a list
        //var actions = new List<ITurnAction>
        //{
        //    new MoveAction("Barbarian", enemyPosition),
        //    new AttackAction("Barbarian", enemy),
        //    new MoveAction("Barbarian", startPosition),
        //    new CastSpellAction("Wizard", enemy),
        //    new HideAction("Rogue"),
        //};

        // Execute each action in the list
        foreach (var action in actions.List)
        {
            if (action == null)
                break;
            // Perform the action
            action.Execute();


            // Wait for the action to finish before moving to the next one
            yield return new WaitUntil(() => action.IsDone);

            if (BattleRecord.CurrentState == EndOfBattle)
                break;
        }

        // All actions have been executed
        Debug.Log("Turn is complete");
        actions.List.Clear();
        ChangePhase();

        NewTurn.Raise();
    }

    private void ChangePhase()
    {
        if (BattleRecord.CurrentState == PlayerPhase)
            BattleRecord.CurrentState = EnemyPhase;
        else if (BattleRecord.CurrentState == EnemyPhase)
            BattleRecord.CurrentState = PlayerPhase;
    }
}

// Example MoveAction
public class MoveAction : ITurnAction
{
    private string characterName;
    private Vector3 targetPosition;

    public MoveAction(string characterName, Vector3 targetPosition)
    {
        this.characterName = characterName;
        this.targetPosition = targetPosition;
    }

    public void Execute()
    {
        IsDone = false;
        Debug.Log(characterName + " moves to " + targetPosition);
        // Your movement logic here
        // Set isDone to true when the movement is complete
        IsDone = true;
    }
    public bool IsDone { get; set; }

}

// Similar implementations for other action types (AttackAction, CastSpellAction, HideAction, etc.)

