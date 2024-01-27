using System;
using UnityEngine;

[Serializable]
public class IntReference
{
    [SerializeField]
    private bool UseConstant = true;
    public int ConstantValue = 1;
    
    public IntVariable Variable;
    public int Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }
}