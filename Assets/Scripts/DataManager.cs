using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;
    private float prevTime;
    private float prevSaveTime;
    private float logInterval = 1;
    private float logSaveInterval = 10;
    private List<CharacterPosition> playerPositions;
    private List<CharacterPosition> enemyPositions;
    // Start is called before the first frame update
    void Start()
    {
        prevTime = Time.realtimeSinceStartup;
        prevSaveTime = prevTime;
        playerPositions = new List<CharacterPosition>();
        enemyPositions = new List<CharacterPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.realtimeSinceStartup;
        if(currentTime > prevTime + logInterval) {
            prevTime += logInterval;
            CharacterPosition cp = new CharacterPosition(player.name, currentTime, player.transform.position);
            playerPositions.Add(cp);
            foreach (GameObject enemy in enemies) {
                CharacterPosition en = new CharacterPosition(enemy.name, currentTime, enemy.transform.position);
                enemyPositions.Add(en);
            }
        }
        if(currentTime > prevSaveTime + logSaveInterval) {
            prevSaveTime += logSaveInterval;
            SaveCSVToFile();
        }
    }

    private void SaveCSVToFile()
    {
        string data = "Name; Timestamp; x; y; z\n";
        foreach (CharacterPosition cp in playerPositions)
        {
            data += cp.ToCSV() + "\n";
        }
        foreach (CharacterPosition cp in enemyPositions)
        {
            data += cp.ToCSV() + "\n";
        }
        FileManger.WriteToFile("positions.csv", data);
    }
}
