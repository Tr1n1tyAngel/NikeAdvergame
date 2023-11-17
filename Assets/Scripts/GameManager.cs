using System.Collections;
using System.Collections.Generic;
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
    public Button attackBtn;
    public float pHealth;
    public float eHealth;
    public int[] weaponsDamage = new int[3];
    public bool win = false;
    public bool lose = false;
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
        if(SceneManager.GetActiveScene().name == "Shop")
        {
            battleCanvas.SetActive(false);
            win = false;
            lose = false;
        }
        else if(SceneManager.GetActiveScene().name == "BattleScene")
        {
            battleCanvas.SetActive(true);
            
        }
    }
}
