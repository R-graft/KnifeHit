using UnityEngine;
public class RandomAppleBehaveur : MonoBehaviour
{
    [SerializeField]
    private GameObject _halfApple;

    private Collider2D _appleCollider;

    private SpriteRenderer _renderer;
    
    private void Awake()
    {
        _appleCollider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _appleCollider.enabled = false;

        int _appleCount = PlayerPrefs.GetInt("apllesScore");

        PlayerPrefs.SetInt("apllesScore", _appleCount + 1);

        _renderer.enabled = false;

        _halfApple.SetActive(true);

        Destroy(gameObject,2);  
    }
}
