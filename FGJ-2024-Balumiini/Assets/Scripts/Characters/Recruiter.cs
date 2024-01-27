using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recruiter : MonoBehaviour
{

    ICombatActions myActions;

    [SerializeField]
    Party party;
    // Start is called before the first frame update
    void Start()
    {
        myActions = GetComponent<ICombatActions>();
        if (myActions != null)
            party.Add(myActions);
    }

    private void OnEnable()
    {
        if (myActions != null)
            party.Add(myActions);
    }

    private void OnDisable()
    {
        if (myActions != null)
            party.Remove(myActions);
    }
}
