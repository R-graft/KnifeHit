using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    public static UnityEvent isHit = new UnityEvent();
    public static UnityEvent isFall = new UnityEvent();
    public static UnityEvent isWin = new UnityEvent();
    public static UnityEvent woodSpawn = new UnityEvent();
}
