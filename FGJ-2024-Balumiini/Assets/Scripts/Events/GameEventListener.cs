using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField]
    UnityEvent Response;

    [SerializeField]
    GameEvent gameEvent;
    public GameEvent MyEvent { get => gameEvent; set => gameEvent = value; }

    public void OnRaised()
    {
        Response?.Invoke();
    }
    private void OnEnable()
    {
        MyEvent.AddListener(this);
    }

    private void OnDisable()
    {
        MyEvent.RemoveListener(this);
    }
}
