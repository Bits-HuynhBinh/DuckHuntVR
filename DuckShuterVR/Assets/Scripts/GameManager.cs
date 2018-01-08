using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject spawnPointRoot;
    public float spawnInterval = 3f;
    public int howManyObjectTospawnForASpawnPoint = 1;
    public float howLongBetweenEachSpawnForASpawnPoint = 1f;
    public int maxEnemyOnScene = 10;
    public int winGameEnemyCount = 20;


    private int enemyOnSceneCount = 0;
    private List<GameObject> spawnPointList = new List<GameObject>();
    private List<int> alreadySpawnedPointIndexs = new List<int>();
    private float currentTime = 0f;

    // Use this for initialization
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < spawnPointRoot.transform.childCount; i++)
        {
            spawnPointList.Add(spawnPointRoot.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(enemyOnSceneCount < maxEnemyOnScene)
        {
            if (currentTime >= spawnInterval)
            {
                int index = Random.Range(0, spawnPointList.Count);

                if (!alreadySpawnedPointIndexs.Contains(index))
                {
                    alreadySpawnedPointIndexs.Add(index);
                    spawnPointList[index].GetComponent<Spawner>().Spawn(howManyObjectTospawnForASpawnPoint, howLongBetweenEachSpawnForASpawnPoint);
                    enemyOnSceneCount++;
                    currentTime = 0f;
                }

                if (alreadySpawnedPointIndexs.Count == spawnPointList.Count)
                {
                    alreadySpawnedPointIndexs.RemoveRange(0, alreadySpawnedPointIndexs.Count);
                    alreadySpawnedPointIndexs.Clear();
                }

            }
        }   
        


        if(winGameEnemyCount <= 0)
        {
            // win - reload scene
            StartCoroutine(reloadScene());
        }
    }

    public void decreaseEnemyWhenDead()
    {
        winGameEnemyCount--;
    }

    public IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }

    public void decreaseEnemyOnSceneCount()
    {
        enemyOnSceneCount--;
    }

}
