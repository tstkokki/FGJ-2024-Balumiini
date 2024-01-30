using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ToggleSpriteOnPhase : MonoBehaviour
{
    [SerializeField]
    BattleRecord battleRecord;

    ReactiveProperty<BattleState> observer;

    SpriteRenderer sprite;

    [SerializeField]
    BattleState visibleOn;

    // Start is called before the first frame update
    void Start()
    {
        sprite= GetComponent<SpriteRenderer>();

        observer = new ReactiveProperty<BattleState>(battleRecord.CurrentState);

        observer
            .ObserveEveryValueChanged(v => battleRecord.CurrentState)
            .TakeUntilDestroy(this)
            .Subscribe(s =>
            {

                sprite.enabled = battleRecord.CurrentState == visibleOn;


            })
            ;
    }

}
