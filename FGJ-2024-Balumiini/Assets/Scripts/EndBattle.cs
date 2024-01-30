using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBattle : MonoBehaviour
{
    [SerializeField]
    BattleRecord BattleRecord;

    [SerializeField]
    BattleState EndOfBattleState;

    
    [SerializeField]
    BattleState PlayerPhase;

    [SerializeField]
    GameEvent LevelUp;

    public void EndOfBattle()
    {
        if (BattleRecord != null)
        {
            BattleRecord.CurrentState = EndOfBattleState;
            LevelUp.Raise();

        }
        StartCoroutine(SetToPlayer());
    }

    IEnumerator SetToPlayer()
    {
        yield return new WaitForSeconds(1f);
        var pc = PlayersQueue.Dequeue();
        pc.SetActive(true);

        yield return new WaitForSeconds(1f);

        BattleRecord.CurrentState = PlayerPhase;

    }

    public List<GameObject> Players = new();

    Queue<GameObject> PlayersQueue = new();

    private void Start()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            PlayersQueue.Enqueue(Players[i]);
        }
    }
}
