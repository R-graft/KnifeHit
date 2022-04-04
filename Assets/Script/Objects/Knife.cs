using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField]
    private Vector2 _force;

    [SerializeField]
    private AudioClip[] _hitClips;

    [SerializeField]
    private AudioClip[] _loseClips;

    [SerializeField]
    private AudioClip _throw;

    private AudioSource _audioSource;

    private BoxCollider2D _boxCollider;

    private ParticleSystem _particleSystem;

    private Rigidbody2D _knifeRb;

    private bool _isActive = true;

    public static int vibrationTime = 100;

    private void Awake()
    {
     _knifeRb = GetComponent<Rigidbody2D>();
     _boxCollider = GetComponent<BoxCollider2D>();
     _audioSource = GetComponent<AudioSource>();
     _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isActive)
        //if (Input.touchCount>0 && _isActive)
       
        {
           // if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _audioSource.PlayOneShot(_throw);
                _knifeRb.AddForce(_force, ForceMode2D.Impulse);
                _knifeRb.gravityScale = 1;
            } 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isActive)
        {
            return;
        }

        if (collision.collider.tag == "wood")
        {
            _knifeRb.velocity = new Vector2(0, 0);
            _knifeRb.bodyType = RigidbodyType2D.Kinematic;

            this.transform.SetParent(collision.collider.transform);

            Vibration.Vibrate(vibrationTime);

            _boxCollider.offset = new Vector2(0.005f, -0.45f);
            _boxCollider.size = new Vector2(0.6f, 1f);

            _particleSystem.Play();

            _audioSource.PlayOneShot(_hitClips[Random.Range(0,2)]);

            _isActive = false;

            Events.isHit.Invoke();
        }

        else if (collision.collider.tag == "knife")
        {
            _knifeRb.velocity = new Vector2(_knifeRb.velocity.x,-2);

            _audioSource.PlayOneShot(_loseClips[Random.Range(0, 1)]);

            _isActive = false;

            Vibration.Vibrate(vibrationTime * 2);

            Events.isFall.Invoke();
        }
    }
}
