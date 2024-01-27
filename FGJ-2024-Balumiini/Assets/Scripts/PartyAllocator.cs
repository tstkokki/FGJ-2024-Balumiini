using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PartyAllocator : MonoBehaviour
{
    public List<Vector3Variable> Slots = new();

    // Start is called before the first frame update
    void Start()
    {
        var myName = gameObject.name;
        var positions = new List<Transform>( GetComponentsInChildren<Transform>()).Skip(1).ToList();
        for (int i = 0; i < positions.Count; i++)
        {
            Transform position = positions[i];
            if(i < Slots.Count)
            {
                Slots[i].Value = position.position;
            }
        }
    }

}
