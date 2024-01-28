using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPartyUIObserver : MonoBehaviour
{
    [SerializeField]
    Party Party;

    [SerializeField]
    Image Icon;

    [SerializeField]
    Image HpFill;

    [SerializeField]
    TextMeshProUGUI Hp;

    [SerializeField]
    TextMeshProUGUI Stats;

    IntReactiveProperty observer;

    // Start is called before the first frame update
    void Start()
    {
        observer = new IntReactiveProperty(Party.CurrentMember.Value);

        observer
            .ObserveEveryValueChanged(v => Party.CurrentMember.Value)
            .TakeUntilDestroy(this)
            .Subscribe(s =>
            {
                UpdateUI();
            });
    }

    public void UpdateUI()
    {
        if (Party.Members.Count > 0)
        {

            var member = Party.Current.Character.BaseStats;
            if (Icon != null && member.Icon != null)
            {
                Icon.sprite = member.Icon;
            }
            Hp.text = $"{member.Hp.Value}/{member.LevelledMaxHp}";
            Stats.text = $"Atk: {member.LevelledAtk}\nDef: {member.LevelledDef}";

            HpFill.fillAmount = (float)member.Hp.Value / member.LevelledMaxHp;
        }
    }
}
