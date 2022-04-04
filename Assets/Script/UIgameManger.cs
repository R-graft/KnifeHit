using UnityEngine;
using UnityEngine.UI;

public class UIgameManger : MonoBehaviour
{
    [Header("Canvas1")]

    [SerializeField]
    private GameObject _startCanvas;

    [SerializeField]
    private Text _MenuAppleScore;

    [SerializeField]
    private Text _bestScore;

    [SerializeField]
    private AudioSource _backMusic;

    [Header("Canvas2")]

    [SerializeField]
    private GameObject _gameCanvas;

    [SerializeField]
    private GameObject _playController;

    [SerializeField]
    private Text _appleScoreGame;

    private int _appleCount;

    private void Awake()
    {
        Events.isHit.AddListener(GetAppleScore);
        Events.isHit.AddListener(GetBestScore);

    }
    void Start()
    {
        GetAppleScore();
        GetBestScore();
        LoadStartMenu();
    }
    public void LoadStartMenu()
    {
        //canvas1 
        _startCanvas.SetActive(true);

        _playController.SetActive(false);
        //canvas2
        _gameCanvas.SetActive(false);
    }
    public void LoadGame()
    {
        //canvas1     
        _startCanvas.SetActive(false);
        //canvas2
        _gameCanvas.SetActive(true);

        _playController.SetActive(true);
    }
    void GetAppleScore()
    {
        if (PlayerPrefs.HasKey("apllesScore"))
        {
            _appleCount = PlayerPrefs.GetInt("apllesScore");
        }
        else { _appleCount = 0;}
    
        _appleScoreGame.text = _appleCount.ToString();
        _MenuAppleScore.text = _appleCount.ToString();
    }
    void GetBestScore()
    {
        if (PlayerPrefs.HasKey("bestScoreCounter"))
        {
            _bestScore.text = "Best score  " + PlayerPrefs.GetInt("bestScoreCounter").ToString();
        }
        else { _bestScore.text = "Best score  " + 0.ToString(); }
    }
}
