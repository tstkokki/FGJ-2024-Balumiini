using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PartyCursorObserver : MonoBehaviour
{
    [SerializeField]
    IntVariable CurrentMember;

    [SerializeField]
    List<Vector3Variable> Slots = new();

    IntReactiveProperty observer;

    [SerializeField]
    Vector3Variable CursorPosition;
    // Start is called before the first frame update
    void Start()
    {
        observer = new IntReactiveProperty(CurrentMember.Value);

        observer
            .ObserveEveryValueChanged(v => CurrentMember.Value)
            .TakeUntilDisable(this)
            .Subscribe(s =>
            {
                if(Slots.Count > 0 && CurrentMember.Value >= 0 && CurrentMember.Value < Slots.Count)
                {
                    CursorPosition.Value = Slots[CurrentMember.Value].Value;   
                }
            })
            ;
    }
}
