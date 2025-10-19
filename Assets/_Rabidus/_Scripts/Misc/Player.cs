using UnityEngine;

public class Player : MonoBehaviour, ITarget
{
    public Transform Target => transform;
}
