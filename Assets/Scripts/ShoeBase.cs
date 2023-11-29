using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Shoe", menuName = "Shoe/Create new shoe")]
[System.Serializable]
public class ShoeBase :ScriptableObject
{
    [SerializeField] public string name;
    [SerializeField] public bool shiny;
    [TextArea]
    [SerializeField] public string description;

    [SerializeField] public Sprite shoeSprite;
    [SerializeField] public Sprite tinyShoeSprite;
    [SerializeField] public Sprite shinySprite;

    public string Name
    {
        get { return name; }
    }
    public Sprite ShoeSprite
    {
        get { return shoeSprite; }
    }
    public Sprite TinyShoeSprite
    {
        get { return shoeSprite; }
    }
    public bool Shiny
    {
        get { return shiny; }
    }
    public Sprite ShinySprite
    {
        get { return shinySprite; }
    }


}
