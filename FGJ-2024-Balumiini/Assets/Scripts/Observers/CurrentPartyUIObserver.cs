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
            var current = Party.Current;
            if (current == null)
                return;
            var member = Party.Current.Character;
            Stats baseStats = member.BaseStats;
            if (Icon != null && baseStats.Icon != null)
            {
                Icon.sprite = baseStats.Icon;
            }
            else
                Icon.sprite= null;
            Hp.text = $"{baseStats.Hp.Value}/{baseStats.LevelledMaxHp}";
            Stats.text = $"Atk: {baseStats.LevelledAtk} " +
                $"({(member.PrimaryAttack() - baseStats.LevelledAtk >= 0 ? "+" : "")}{member.PrimaryAttack() - baseStats.LevelledAtk}" +
                $"/{(member.SecondaryAttack() - baseStats.LevelledAtk >= 0 ? "+" : "")}{member.SecondaryAttack() - baseStats.LevelledAtk})\nDef: {baseStats.LevelledDef}";

            HpFill.fillAmount = (float)baseStats.Hp.Value / baseStats.LevelledMaxHp;
        }
    }
}
