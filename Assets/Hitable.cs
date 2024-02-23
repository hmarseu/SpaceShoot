using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    EnemyAI EnemyAI;
    public int LifePoint;

    public delegate void Score(int score);
    public static event Score score;

    public delegate void Died(Vector3 position,bool isgolden);
    public static event Died enemyDie;
    bool isGolden;
    void Start()
    {
     EnemyAI = GetComponent<EnemyAI>();
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
        LifePoint--;
        if (LifePoint <= 0 )
        {
            EnemyAI.EnemyDie = true;
            Die();
        }
    }
    private void Die()
    {
        //Debug.Log("EnnemyMort");
        if (this.GetComponent<SpriteRenderer>().color == new Color(255, 215, 0))
        {
            isGolden = true;
        }
        else
        {
            isGolden = false;
        }
        enemyDie(transform.position, isGolden);
        score(10);
        GlobalPoolObject.Instance.ClearOneEmpty(this.gameObject);
    }
}
