using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<Shoe> enemyShoes;
    
    public Shoe GetRandomShoe()
    {
        int shiny = Random.Range(0, 2);
        int rnd = Random.Range(0, enemyShoes.Count);
        GameManager.Instance.enemyName.text = enemyShoes[rnd].Base.Name;
        if(shiny ==0)
        {
            GameManager.Instance.enemyImage.sprite=enemyShoes[rnd].Base.ShinySprite;
        }
        else
        {
            GameManager.Instance.enemyImage.sprite = enemyShoes[rnd].Base.ShoeSprite;
        }
        return enemyShoes[rnd];
      
    }
}
