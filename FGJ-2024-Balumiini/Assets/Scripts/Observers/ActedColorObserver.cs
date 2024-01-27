using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ActedColorObserver : MonoBehaviour
{

    [SerializeField]
    BooleanVariable HasActed;

    BoolReactiveProperty observer;

    public Color HasActedColor = Color.gray;
    public Color DefaultColor = Color.white;

    SpriteRenderer cat;

    // Start is called before the first frame update
    void Start()
    {

        cat = GetComponent<SpriteRenderer>();

        observer = new BoolReactiveProperty(HasActed.Value);

        observer
            .ObserveEveryValueChanged(v => HasActed.Value)
            .TakeUntilDestroy(this)
            .Subscribe(s =>
            {
                ChangeColor();
            });
        
    }

    public void ChangeColor()
    {
        cat.color = HasActed.Value ? HasActedColor : DefaultColor;
    }
}
