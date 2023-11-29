using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Player : MonoBehaviour
{
    [SerializeField] public LayerMask solidObjects;
    [SerializeField] public LayerMask shelvesLayer;
    public float movementSpeed;
    public bool isMoving = false;
    private Vector2 input;
    public SpriteRenderer playerSprite;
    public Sprite Character1;
    public Sprite Character2;


    private void Update()
    {
        
        if (GameManager.Instance.CH1 == true)
        {
            playerSprite.sprite = Character1;
        }
        else if (GameManager.Instance.CH2 == true)
        {
            playerSprite.sprite = Character2;
        }
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if(input!=Vector2.zero)
            {
                var targetPos=transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
                
            }
        }



    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while((targetPos-transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position,targetPos,movementSpeed*Time.deltaTime);
            yield return null;
        }
        transform.position= targetPos;
        isMoving = false;

        CheckForEncounters();
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos,0.2f,solidObjects)!=null)
        {
            return false;
        }
        return true;
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, shelvesLayer)!=null)
        {
            if(Random.Range(1, 101) <= 10)
            {
                GameManager.Instance.encounter = true;
                SceneManager.LoadScene("BattleScene");
            }
        }
    }
}
