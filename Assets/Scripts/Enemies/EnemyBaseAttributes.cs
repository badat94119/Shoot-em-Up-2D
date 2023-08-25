using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Attributes", menuName = "ScriptableObjects/Enemy Base Attributes", order = 1)]
public class EnemyBaseAttributes : ScriptableObject
{
    [field: SerializeField]
    public int KillScore { get; private set; }

}
