using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject battleCanvas;
    public GameObject playerHealthBar;
    public GameObject enemyHealthBar;
    public GameObject pHBFill;
    public GameObject eHBFill;
    public GameObject weaponDropdown;
    public GameObject upgradeMenu;
    public GameObject pauseMenu;
    public Button attackBtn;
    public float pHealth;
    public float eHealth;
    public int[] weaponsDamage = new int[3];
    public bool win = false;
    public bool lose = false;
    public bool CH1 = false;
    public bool CH2 = false;
    public bool encounter = false;
   public bool caught= false;
    public ShoeInventory shoeInventory;
    public TextMeshProUGUI enemyName;
    public EnemySpawn enemySpawn;
    public Image playerImage;
    public Image enemyImage;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        pHealth = 100;
        eHealth = 100;
    }
    private void Start()
    {
        
        
        win = false;
        lose = false;
        
        weaponsDamage[0] = 50;
        weaponsDamage[1] = 25;
        weaponsDamage[2] = 15;
    }

    private void Update()
    {
        if(encounter==true)
        {
            enemySpawn.GetRandomShoe();
            encounter = false;
        }
        if (SceneManager.GetActiveScene().name != "Shop")
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            
            pauseMenu.SetActive(true);
            
        }

        if (SceneManager.GetActiveScene().name == "Shop")
        {
            upgradeMenu.SetActive(false);
            battleCanvas.SetActive(false);
            win = false;
            lose = false;
           
        }
        else if(SceneManager.GetActiveScene().name == "BattleScene")
        {
            battleCanvas.SetActive(true);
            
        }
    }
    public void SavePlayerData()
    {
        SaveSystem.SavePlayerData(this);
        Debug.Log("Data saved");
    }
    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayerData();
        pHealth = data.pHealth;
        for(int i = 0; i<3; i++)
        {
            weaponsDamage[i] = data.weaponsDamage[i];
        }
        SceneManager.LoadScene("Shop");
    }
}
