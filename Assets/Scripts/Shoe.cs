using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shoe
{
    [SerializeField] ShoeBase _base;

    public ShoeBase Base
    { get { return _base; } }
    
}
