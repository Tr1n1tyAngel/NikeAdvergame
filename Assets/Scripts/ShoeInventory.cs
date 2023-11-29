using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShoeInventory : MonoBehaviour
{
    [SerializeField] public List<Shoe> shoes;
    [SerializeField]public InventoryDisplay display;

    public void AddShoe(Shoe newShoe)
    {
        shoes.Add(newShoe);
        display.RefreshInventoryDisplay();
    }
}
