using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Health : MonoBehaviour
{
    

    public float pHealthMax ;
    public float eHealthMax ;
    public Vector2 pLocalScale;
    public Vector2 eLocalScale;
    
   
    
    
        // Start is called before the first frame update
        void Start()
    {

        
        pHealthMax = GameManager.Instance.pHealth;
        eHealthMax = GameManager.Instance.eHealth;
        GameManager.Instance.pHBFill = GameManager.Instance.playerHealthBar.transform.GetChild(1).gameObject;
        GameManager.Instance.eHBFill = GameManager.Instance.enemyHealthBar.transform.GetChild(1).gameObject;
        pLocalScale = GameManager.Instance.pHBFill.transform.localScale;
        eLocalScale = GameManager.Instance.eHBFill.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar();
        MaxMinHealth();
        HealthBarColour();
        

    }

    public void HealthBar()
    {
        if(GameManager.Instance.pHBFill != null||GameManager.Instance.eHBFill != null)
        {
            pLocalScale.x = GameManager.Instance.pHealth / 100;
            GameManager.Instance.pHBFill.transform.localScale = pLocalScale;
            eLocalScale.x = GameManager.Instance.eHealth / 100;
            GameManager.Instance.eHBFill.transform.localScale = eLocalScale;
            if (GameManager.Instance.pHealth <= 0 && GameManager.Instance.win != true)
            {
                GameManager.Instance.lose = true;
                GameManager.Instance.win = false;
            }
            if (GameManager.Instance.eHealth <= 0 && GameManager.Instance.lose != true)
            {
                GameManager.Instance.win = true;
                GameManager.Instance.lose = false;
            }
        }
       
    }
    public void HealthBarColour()
    {
        if (GameManager.Instance.pHBFill != null || GameManager.Instance.eHBFill != null)
        {
            if (GameManager.Instance.pHealth > 50)
            {
                GameManager.Instance.pHBFill.GetComponent<Image>().color = Color.green;
            }
            else if (GameManager.Instance.pHealth <= 50 && GameManager.Instance.pHealth > 25)
            {
                GameManager.Instance.pHBFill.GetComponent<Image>().color = Color.yellow;
            }
            else if (GameManager.Instance.pHealth <= 25 && GameManager.Instance.pHealth > 0)
            {
                GameManager.Instance.pHBFill.GetComponent<Image>().color = Color.red;
            }


            if (GameManager.Instance.eHealth > 50)
            {
                GameManager.Instance.eHBFill.GetComponent<Image>().color = Color.green;
            }
            else if (GameManager.Instance.eHealth <= 50 && GameManager.Instance.eHealth > 25)
            {
                GameManager.Instance.eHBFill.GetComponent<Image>().color = Color.yellow;
            }
            else if (GameManager.Instance.eHealth <= 25 && GameManager.Instance.eHealth > 0)
            {
                GameManager.Instance.eHBFill.GetComponent<Image>().color = Color.red;
            }
        }
    }
        
    public void MaxMinHealth()
    {
        if (GameManager.Instance.pHealth > pHealthMax)
        {
            GameManager.Instance.pHealth = pHealthMax;
        }
        if (GameManager.Instance.eHealth > eHealthMax)
        {
            GameManager.Instance.eHealth = eHealthMax;
        }
        if (GameManager.Instance.pHealth < 0)
        {
            GameManager.Instance.pHealth = 0;
        }
        if (GameManager.Instance.eHealth < 0)
        {
            GameManager.Instance.eHealth = 0;
        }
    }
}
