using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ActionList", menuName = "Custom/Action List")]
public class ActionList : ScriptableObject
{
    List<ITurnAction> list = new();

    public List<ITurnAction> List { get => list; }

    public void Add(ITurnAction action)
    {
        list.Add(action);
    }
}
