using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    PartyAction Party;
    [SerializeField]
    GameEvent ExecuteTurn;

    [SerializeField]
    BattleRecord BattleRecord;
    [SerializeField]
    BattleState MyPhase;
    // Start is called before the first frame update
    void Start()
    {
        Party = GetComponent<PartyAction>();

    }
    public void OnEnemyPhase()
    {
        if (BattleRecord.CurrentState == MyPhase)
        {

            Party.ResetTurn();

            Party.AddToTurn();
            ExecuteTurn.Raise();
        }
    }
}
