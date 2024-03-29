using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Transform contentPanel; 
    public Image selectedShoeImage; 
    public GameObject textTemplate;
    public NPCManager npcManager;
    
    [SerializeField] public TextMeshProUGUI shoeAmount;
    // List to store all shoes

    void Start()
    {
        PopulateScrollView();
    }
    private void Update()
    {
        shoeAmount.text = "Shoes given to customers: " + GameManager.Instance.countRemoved;
    }
    void PopulateScrollView()
    {
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }
        foreach (Shoe shoe in GameManager.Instance.shoeInventory.shoes)
        {
            GameObject newTextObject = Instantiate(textTemplate, contentPanel);
            
            newTextObject.SetActive(true);

            TextMeshProUGUI shoeNameText = newTextObject.GetComponentInChildren<TextMeshProUGUI>();
           
            shoeNameText.text = shoe.Base.Name;
            
            Button button = newTextObject.GetComponentInChildren<Button>();
            if (button)
            {
                button.onClick.RemoveAllListeners();
                string shoeName=shoe.Base.Name;
                button.onClick.AddListener(() => OnShoeSelected(shoe,shoeName));
            }
        }
    }

    public void RefreshInventoryDisplay()
    {
        PopulateScrollView();
    }
    void OnShoeSelected(Shoe shoe,string shoeName)
    {
        AudioManager.instance.Play("Button");
        selectedShoeImage.sprite = shoe.Base.TinyShoeSprite;

        if (npcManager.select == true)
        {
            foreach (NPC npc in npcManager.npcs)
            {
                if (shoeName == npc.shoe[npc.rnd])
                {
                    ConfirmRemoveShoe(shoe);
                    npc.RandomShoe();
                    npcManager.select = false;
                }
            }
        }
           
        
        
    }

    void ConfirmRemoveShoe(Shoe shoe)
    {
        GameManager.Instance.countRemoved++;
        GameManager.Instance.shoeInventory.shoes.Remove(shoe);
        RefreshInventoryDisplay();
    }
}
