using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wave {
	public GameObject enemyPrefab;
	public float spawnInterval = 2;//时间间隔
	public int maxEnemies = 20;
}

public class SpawnEnemy : MonoBehaviour {

	public GameObject[] waypoints;
	public GameObject testEnemyPrefab;

	public Wave[] waves;//关卡的难易度属性
	public int timeBetweenWaves = 5;
	
	private GameManagerBehavior gameManager;
	
	private float lastSpawnTime;
	private int enemiesSpawned = 0;
    private GameObject GetuiR;
    public GameObject trager;
    // Use this for initialization
    void Start () {
		lastSpawnTime = Time.time;
		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        

    }
	
	// Update is called once per frame
	void Update () {
		// 1
		int currentWave = gameManager.Wave;//将波数赋值
		if (currentWave < waves.Length) {
			// 2
			float timeInterval = Time.time - lastSpawnTime;//获取时间
			float spawnInterval = waves[currentWave].spawnInterval;
			if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
			     timeInterval > spawnInterval) && 
			    enemiesSpawned < waves[currentWave].maxEnemies) {
				// 3  
				lastSpawnTime = Time.time;
				GameObject newEnemy = (GameObject)Instantiate(waves[currentWave].enemyPrefab, trager.transform.position,Quaternion.identity);
                newEnemy.transform.parent = trager.transform.parent;
                newEnemy.transform.rotation = Quaternion.Euler(0,0,-90);
                newEnemy.transform.localScale = Vector3.one;
                // newEnemy.transform.parent = GetuiR.transform;

                newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
				enemiesSpawned++;
               // print(enemiesSpawned);
			}
			// 4 
			if (enemiesSpawned == waves[currentWave].maxEnemies &&
			    GameObject.FindGameObjectWithTag("Enemy") == null) {
				gameManager.Wave++;
				GameManagerBehavior.Gold = Mathf.RoundToInt(GameManagerBehavior.Gold * 1.1f);
				enemiesSpawned = 0;
				lastSpawnTime = Time.time;
			}
			// 5 
		} else//当波数完了执行下面代码
        {
			gameManager.gameOver = true;
            SelectLevel.index++;
			GameObject gameOverText = GameObject.FindGameObjectWithTag ("GameWon");
			gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
		}	
	}
}
