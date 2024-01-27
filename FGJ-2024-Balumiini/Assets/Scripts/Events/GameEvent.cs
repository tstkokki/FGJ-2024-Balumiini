using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Custom/Game Event")]
public class GameEvent : ScriptableObject
{
    List<IGameEventListener> listeners = new List<IGameEventListener>();

    public void Raise()
    {
        for(int i = listeners.Count-1; i >= 0; i--)
        {
            listeners[i].OnRaised();
        }
    }

    public void AddListener(IGameEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void RemoveListener(IGameEventListener listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }

}
