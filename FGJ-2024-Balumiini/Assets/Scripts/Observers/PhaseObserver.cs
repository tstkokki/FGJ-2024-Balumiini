using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class PhaseObserver : MonoBehaviour
{
    [SerializeField]
    BattleRecord BattleRecord;

    ReactiveProperty<BattleState> observer;
    TextMeshProUGUI UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<TextMeshProUGUI>();

        observer = new ReactiveProperty<BattleState>(BattleRecord.CurrentState);

        observer
            .ObserveEveryValueChanged(v => BattleRecord.CurrentState)
            .TakeUntilDestroy(this)
            .Subscribe(s =>
            {
                UI.text = BattleRecord.CurrentState.name.ToString();
            });
    }

}
