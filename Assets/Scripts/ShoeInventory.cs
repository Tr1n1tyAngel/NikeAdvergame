using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeInventory : MonoBehaviour
{
    [SerializeField] List<Shoe> shoes;

    public void AddShoe(Shoe newShoe)
    {
        shoes.Add(newShoe);
    }
}
