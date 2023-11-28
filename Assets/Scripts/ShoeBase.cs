using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Shoe", menuName = "Shoe/Create new shoe")]
public class ShoeBase :ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] bool shiny;
    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite shoeSprite;
    [SerializeField] Sprite shinySprite;

    public string Name
    {
        get { return name; }
    }
    public Sprite ShoeSprite
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
