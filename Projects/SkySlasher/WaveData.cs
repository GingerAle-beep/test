using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemySpawner;

/// <summary>
/// cointains the data of each wave
/// </summary>
[CreateAssetMenu(fileName = "WaveData", menuName = "Wave Data")]
public class WaveData : ScriptableObject
{
    public List<EnemySpawnInfo> EnemyChances;
    public float SpawnInterval;
    public int MaxEnemyCount;

}
