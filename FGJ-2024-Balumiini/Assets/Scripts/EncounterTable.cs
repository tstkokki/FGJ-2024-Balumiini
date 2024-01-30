using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterTable : MonoBehaviour
{

    public List<GameObject> Enemies = new();

    Queue<GameObject> EnemiesQueue = new();
    // Start is called before the first frame update
    void Start()
    {
        if (Enemies.Count > 0)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {

                EnemiesQueue.Enqueue(Enemies[i]);
            }
            NextEncounter();
        }
    }

    public void NextEncounter()
    {
        if (EnemiesQueue.Count == 0)
            SceneManager.LoadScene(2);
        else
        StartCoroutine(NextEnemyDelay());
    }

    IEnumerator NextEnemyDelay()
    {
        yield return new WaitForSeconds(0.5f);

        if (EnemiesQueue.Count > 0)
        {

            var enemy = EnemiesQueue.Dequeue();
            if (enemy != null)
            {
                enemy.SetActive(true);
            }
        }
    }
}
