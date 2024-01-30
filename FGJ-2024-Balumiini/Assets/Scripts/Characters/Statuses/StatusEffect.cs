using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Status", menuName = "Custom/Combat/Status")]
public class StatusEffect : ScriptableObject, IStatus
{
    public string StatusName = "";
    public string Name => StatusName;

    public int atkEffect;
    public int defEffect;
    public int AtkEffect => atkEffect;

    public int DefEffect => atkEffect;

    [SerializeField]
    StatusType statusType;

    public StatusType Type { get => statusType; }
}
