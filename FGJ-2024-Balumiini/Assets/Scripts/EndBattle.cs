using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBattle : MonoBehaviour
{
    [SerializeField]
    BattleRecord BattleRecord;

    [SerializeField]
    BattleState EndOfBattleState;


    public void EndOfBattle()
    {
        if (BattleRecord != null)
            BattleRecord.CurrentState = EndOfBattleState;
        var pc = PlayersQueue.Dequeue();
        pc.SetActive(true);
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
