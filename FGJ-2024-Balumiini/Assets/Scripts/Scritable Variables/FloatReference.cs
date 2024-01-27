using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatReference
{
    [SerializeField]
    private bool UseConstant = true;
    public float ConstantValue = 1;

    public FloatVariable Variable;
    public float Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }
}