using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableBoss : MonoBehaviour
{
  
    public int LifePoint;
    public int totalLP;

    public delegate void Score(int score);
    public static event Score score;

    public delegate void DiedBoss();
    public static event DiedBoss bossdie;

    public delegate void BossTakeHit(int lifePoint,int total);
    public static event BossTakeHit bossTakeHit;
    void Start()
    {
        totalLP = LifePoint;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision détectée avec : " + other.gameObject.name);
        if (other.gameObject.tag == "PlayerMissile")
        {
            GetHit();
        }
    }
    private void GetHit()
    {
        StartCoroutine(Gettouch());
        LifePoint--;
        bossTakeHit(LifePoint, totalLP);
        if (LifePoint <= 0 )
        {
            Die();

            
        }
    }
    private void Die()
    {
        Debug.Log("EnnemyMort");
        bossdie();

        score(30);
        GlobalPoolObject.Instance.ClearOneEmpty(this.gameObject);
    }
    IEnumerator Gettouch()
    {
   
        bool color = true;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color Corigine = spriteRenderer.color;
        if (spriteRenderer != null)
        {
            for (int i = 0; i < 3; i++)
            {
                if (color)
                {
                    spriteRenderer.color = Color.red;
                    color = false;
                }
                else
                {
                    spriteRenderer.color = Color.yellow;
                    color = true;
                }
                yield return new WaitForSeconds(0.2f);

            }
        }
        spriteRenderer.color = Corigine;
        yield return null;
    }
}
