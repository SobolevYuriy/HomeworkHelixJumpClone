using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject FirstPlatformPrefab;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float DistanceBetweenPlatforms;
    public Transform PlatformFinish;
    public Transform CylinderRoot;
    public float ExtraCylinderScale = 1f;
    public GameStatus GameStatus;

    private void Awake()
    {
        int LevelIndex = GameStatus.LevelIndex;
        Random random = new Random(LevelIndex);
        int platformCount = RandomRange(random, MinPlatforms, MaxPlatforms + 1);

        for (int i=0; i < platformCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, PlatformPrefabs.Length);
            GameObject platformPrefab =  i==0 ? FirstPlatformPrefab : PlatformPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if(i>0)
                platform.transform.localRotation = Quaternion.Euler(0, RandomRange(random,0, 360f), 0);
        }

        PlatformFinish.localPosition = CalculatePlatformPosition(platformCount);
        CylinderRoot.localScale = new Vector3(1, platformCount * DistanceBetweenPlatforms+ExtraCylinderScale, 1);
        
    }

    private int RandomRange(Random random, int  min, int maxExclusive)
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }

    private float RandomRange(Random random, float min, float max)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -DistanceBetweenPlatforms * platformIndex, 0);
    }
}
