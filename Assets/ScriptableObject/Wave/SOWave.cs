using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave",menuName ="ScriptableObject/Wave")]
public class SOWave : ScriptableObject
{
    public float timeBtwSpawn;
    public float timeBtwWave;
    public List<GameObject> enemysInWave;
}
