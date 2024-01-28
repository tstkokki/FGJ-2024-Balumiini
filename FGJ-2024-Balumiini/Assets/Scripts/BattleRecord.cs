using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Battle Record", menuName = "Custom/Battle Record")]
public class BattleRecord : ScriptableObject
{
    public BattleState CurrentState;
    public int Turn;
}
