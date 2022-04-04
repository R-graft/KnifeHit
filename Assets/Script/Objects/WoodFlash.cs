using UnityEngine;

public class WoodFlash : MonoBehaviour
{
    private ParticleSystem _woodParticleSystem;
   void Awake()
    {
        _woodParticleSystem = GetComponent<ParticleSystem>();
    }
    private void Start()
    {
        Events.isHit.AddListener(PlayParticleSystemOnHit);
    }
    void PlayParticleSystemOnHit()
    {
        _woodParticleSystem.Play();
    }
}
