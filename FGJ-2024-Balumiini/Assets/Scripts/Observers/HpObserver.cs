using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HpObserver : MonoBehaviour
{
    ICombatActions MyActions;

    IntReactiveProperty observer;

    // Start is called before the first frame update
    void Start()
    {
        MyActions = GetComponent<ICombatActions>();

        observer = new IntReactiveProperty(MyActions.Character.BaseStats.Hp.Value);

        observer
            .ObserveEveryValueChanged(v => MyActions.Character.BaseStats.Hp.Value)
            .TakeUntilDisable(gameObject)
            .Subscribe(s =>
            {
                if(MyActions.Character.BaseStats.Hp.Value <= 0)
                    gameObject.SetActive(false);
            });
    }

}
