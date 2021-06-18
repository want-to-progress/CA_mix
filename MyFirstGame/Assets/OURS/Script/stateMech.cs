using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "stateMech", menuName = "state")]
public class stateMech : ScriptableObject
{
    public int state = 1;
    public bool together = true;
}
