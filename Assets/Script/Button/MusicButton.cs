using UnityEngine;

public class MusicButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _buttonOn;
    [SerializeField]
    private GameObject _buttonOff;
    [SerializeField]
    private AudioSource _music;

    public void ImageChange()
    {
        
        if (_buttonOn.activeSelf)
        {
            _buttonOn.SetActive(false);
            _buttonOff.SetActive(true);
            _music.enabled = false;
            return;
        }
        if (!_buttonOn.activeSelf)
        {
            _buttonOff.SetActive(false);
            _buttonOn.SetActive(true);
            
            _music.enabled = true;
            return;
        }
    }
}
