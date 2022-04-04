using UnityEngine;

public class VibrateButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _buttonOn;

    [SerializeField]
    private GameObject _buttonOff;

    public void ImageChange()
    {

        if (_buttonOn.activeSelf)
        {
            Knife.vibrationTime = 1;

            _buttonOn.SetActive(false);
            _buttonOff.SetActive(true);

            return;
        }
        if (!_buttonOn.activeSelf)
        {
            Knife.vibrationTime = 100;

            _buttonOff.SetActive(false);
            _buttonOn.SetActive(true);
            
            return;
        }
    }
}
