using UnityEngine;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{
    [SerializeField]
    private GameObject _knifeprefab;

    [SerializeField]
    private GameObject _wood;

    [SerializeField]
    private GameObject _crashWood;

    [SerializeField]
    private GameObject _restart;

    [SerializeField]
    private GameObject _miniKnife;

    [SerializeField]
    private GameObject _miniKnivesPanel;

    [SerializeField]
    private Text _gameScore;

    [SerializeField]
    private Text _panelLevel;

    private int _knivesCount;

    private int _miniKnivesCount;

    private int _gameScoreCounter = 0;

    public static int _levelNumber = 1;

    private void Awake()
    {
        Events.isHit.AddListener(IsHit);
        Events.isFall.AddListener(Islose);
        Events.isWin.AddListener(IsWin);
        Vibration.Init();
    }
    public void StartGame()
    {
        if (_restart)
        {
            _restart.SetActive(false);       
        }
        GetKnivesCount(_levelNumber);
        _miniKnivesCount = _knivesCount;

        DestroyAllMiniKnives();
        SpawnMiniknives(_knivesCount);

        WoodSpawn();

        DestroyKnives();

        Invoke("KnivesSpawn", 0.5f);

        _panelLevel.text ="LEVEL"+_levelNumber.ToString();
    }
    void IsHit() // if knife is hitted
    {
        DestroyMiniKnives(_knivesCount);

        GameScoreCalculation();

        KnivesSpawn();

        _knivesCount--;
    }
    void IsWin() // if level win
    {
        Instantiate(_crashWood, new Vector2(0f, 1.3f), Quaternion.identity);

        DestroyKnives();

        Destroy(GameObject.FindGameObjectWithTag("crashWood"), 2);

        Destroy(GameObject.FindGameObjectWithTag("wood"),0.1f);
        
        Invoke("StartGame", 1);

        _levelNumber++;
    }
    void Islose() // if level is lose
    {
        _levelNumber = 1;

        _gameScoreCounter = 0;
        _gameScore.text = _gameScoreCounter.ToString();

        _restart.SetActive(true);
    }
    void SpawnMiniknives(int count) // Create miniKnives on panel
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(_miniKnife, _miniKnivesPanel.transform);
        }
    }
    void DestroyMiniKnives(int count) // Destroy miniKnives on panel if Knife is hitted
    {
        if (count > 0)
        {
            _miniKnivesPanel.transform.GetChild(_miniKnivesCount - count).GetComponent<Image>()
                .color = Color.gray;
        }
        else { return; }
    }
    private void DestroyAllMiniKnives() // destroy all miniknives
    {
        foreach(var item in GameObject.FindGameObjectsWithTag("miniKnife"))
        {
            Destroy(item);
        }
    }
    void WoodSpawn() // spawning new wood
    {
        if (GameObject.FindGameObjectWithTag("wood"))
        {
            Destroy(GameObject.FindGameObjectWithTag("wood"));

            Instantiate(_wood, new Vector2(0f, 1.4f), Quaternion.identity);

            Events.woodSpawn.Invoke();
        }
        else 
        {
            Instantiate(_wood, new Vector2(0f, 1.5f), Quaternion.identity); 
        }
    }
    
   void  KnivesSpawn() //spawn new knife
    {
        if (_knivesCount - 1 > 0)
        {
            Instantiate(_knifeprefab, new Vector2(0.004f, -3f), Quaternion.identity);
        }
        else if(_knivesCount - 1 == 0)
        {
            Events.isWin.Invoke();
        }
    }
    public void DestroyKnives() // destroy knives after win
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("knife"))
        {
            item.transform.SetParent(null);
            item.GetComponent<Collider2D>().enabled = false;
            item.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-8, 8), -10);

            Destroy(item, 2);
        }
    }
    void GameScoreCalculation() // increment score on screen
    {
        _gameScoreCounter ++;
        _gameScore.text = _gameScoreCounter.ToString();

        if (_gameScoreCounter > PlayerPrefs.GetInt("bestScoreCounter"))
        {
            PlayerPrefs.SetInt("bestScoreCounter", _gameScoreCounter);
        }
    }
    int GetKnivesCount(int level) // get count of knives on start level
    {
        if (level > 5)
        {
            level = System.Convert.ToInt32(level / 5);
        }

            switch (level)
            {
                case 1:
                    _knivesCount = 6;
                    break;
                case 2:
                    _knivesCount = 7;
                    break;
                case 3:
                    _knivesCount = 8;
                    break;
                case 4:
                    _knivesCount = 9;
                    break;
                case 5:
                    _knivesCount = 10;
                    break;
        }
        return _knivesCount;

    }

   
}
