using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private Vorota vrat;
    public GameObject[] enemyTypes;
    public Transform[] enemySpawners;

    [HideInInspector] public List<GameObject> enemies;
    private bool spawned;

    void Start()
    {
        vrat = GameObject.Find("dver").GetComponent<Vorota>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !spawned)
        {
            spawned = true;
            foreach (Transform spawner in enemySpawners)
            {
                int rand = Random.Range(0, 10);
                if (rand < 10)
                {
                    GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                    GameObject enemy = Instantiate(enemyType, spawner.position, Quaternion.identity) as GameObject;
                    enemy.transform.parent = transform;
                    enemies.Add(enemy);
                }

            }
            StartCoroutine(CheckEnemies());
        }
        else if (other.CompareTag("Player") && spawned)
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy>().playerNotInRoom = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && spawned)
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy>().playerNotInRoom = true;
            }
        }
    }
    IEnumerator CheckEnemies()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => enemies.Count == 0);
        vrat.BossDead(true);
    }








}
