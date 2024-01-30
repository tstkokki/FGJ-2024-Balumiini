using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class TakeDmgObserver : MonoBehaviour
{
    ICombatActions MyActions;

    IntReactiveProperty observer;
    SpriteRenderer sprite;

    int previousHp;
    // Start is called before the first frame update
    void Start()
    {
        MyActions = GetComponent<ICombatActions>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        if (MyActions != null && sprite != null)
        {

            observer = new IntReactiveProperty(MyActions.Character.BaseStats.Hp.Value);
            previousHp = MyActions.Character.BaseStats.Hp.Value;
            observer
                .ObserveEveryValueChanged(v => MyActions.Character.BaseStats.Hp.Value)
                .TakeUntilDisable(gameObject)
                .Subscribe(s =>
                {
                    StartCoroutine(ColorSwapper());
                });
        }
    }
    WaitForSeconds blinkDelay = new WaitForSeconds(0.2f);
    IEnumerator ColorSwapper()
    {

        if (MyActions.Character.BaseStats.Hp.Value < previousHp)
            sprite.color = Color.red;
        else
            sprite.color = Color.green;

        yield return blinkDelay;
        sprite.color = Color.white;
    }


}
