using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClick : MonoBehaviour
{
    AudioSource _audioSourse;
    private void Awake()
    {
      _audioSourse = GetComponent<AudioSource>();
    }
   public void PlayOnClick()
    {
        _audioSourse.Play();
    }
}
