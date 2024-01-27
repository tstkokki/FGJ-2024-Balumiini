using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CombatCursor : MonoBehaviour
{
    [SerializeField]
    Vector3Variable CursorPosition;

    [SerializeField]
    Vector3 offset;
    ReactiveProperty<Vector3> observer;
    // Start is called before the first frame update
    void Start()
    {
        observer = new ReactiveProperty<Vector3>(CursorPosition.Value);
        observer
            .ObserveEveryValueChanged(v => CursorPosition.Value)
            .TakeUntilDisable(this)
            .Subscribe(s =>
            {
                transform.position = CursorPosition.Value + offset;
            });
    }

}
