using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//產生敵人
public class SpawnManager : MonoBehaviour
{
    //UI
    public TextMeshProUGUI countdownText;

    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public int waveIndex = 0;
    public float timeBetweenEnemies = 0.1f;
    public int timeBetweenWaves = 5;
    public bool isWave = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWave){
            StartCoroutine(Countdown());
            StartCoroutine(SpawnWave());
        }
    }
    IEnumerator Countdown(){
        isWave = true;
        for (int countdown = timeBetweenWaves; countdown > 0; countdown--){
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1);
        }
        isWave = false;
    }
    IEnumerator SpawnWave(){
        waveIndex++;
        for (int i = 0; i < waveIndex; i++){
            SpawnEnemy(enemyPrefab);
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    void SpawnEnemy(GameObject enemy){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
