using UnityEngine;

public class ApplesAndKnivesSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _circleApple;

    [SerializeField]
    private GameObject _circleKnife;

    private int[] randomAngles = new int[4] {0,90,180,270};

    private int appleChanse;

    private void Awake()
    {
        Events.woodSpawn.AddListener(Start);
    }
    void Start()
    {
        if (PlayController._levelNumber != 1)
        {
            SpawnRandomKnives();
            SpawnRandomapple();
        }
        else { return; }
    }
   void SpawnRandomapple()
    {
        appleChanse = Random.Range(1, 4);

        if (appleChanse == 2)
        {
            int randomAppleAngle = randomAngles[Random.Range(0, 3)];

            GameObject _myApple = Instantiate(_circleApple, transform);

            _myApple.transform.position = GetRandomPosition(randomAppleAngle);

            _myApple.transform.Rotate(new Vector3(0, 0, randomAppleAngle));
        }
        else { return; }
    }
    void SpawnRandomKnives()
    {
        int RandomKnivesCount = Random.Range(1, 3);

        for (int i = 0; i < RandomKnivesCount; i++)
        {
            int randomKnifeAngle = randomAngles[i] + 45;

            GameObject _myKnife = Instantiate(_circleKnife, transform);

            _myKnife.transform.position = GetRandomPosition(randomKnifeAngle);

            _myKnife.transform.Rotate(new Vector3(0, 0, randomKnifeAngle));
        }
    }
    Vector2 GetRandomPosition(float randomAngle)
    {
        Vector2 woodPosition = transform.position;

        randomAngle = randomAngle * Mathf.Deg2Rad;

        Vector2 spawnPosition = woodPosition + new Vector2(1.28f * Mathf.Cos(randomAngle), 1.22f * Mathf.Sin(randomAngle));

        return spawnPosition;
    }
}
