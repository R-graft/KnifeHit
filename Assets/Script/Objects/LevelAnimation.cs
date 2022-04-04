using UnityEngine;

public class LevelAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Events.isWin.AddListener(Start);
    }
    void Start()
    {
        _animator.SetTrigger("Level++");
    }
}
