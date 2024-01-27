using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEventListener
{
    public GameEvent MyEvent {get; set; }
    public void OnRaised();

}
