using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    [Header("Walls")]
    public GameObject[] walls;

    [Header("Enemies")]
    public GameObject[] enemyTypes;
    public Transform[] enemySpawners;

    [HideInInspector] public List<GameObject> enemies;
    private RoomVariants variants;
    private bool spawned;
    private bool wallsDestroyed;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
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
          //  Debug.Log("Pk");
        }
    }
    IEnumerator CheckEnemies()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Ну я и");
        yield return new WaitUntil(() => enemies.Count == 0);
        Debug.Log("Я сработал");
        DestroyWalls();
        Debug.Log("1");
    }
    public void DestroyWalls()
    {
        foreach (GameObject wall in walls)
        {
            if (wall != null && wall.transform.childCount != 0)
            {
              //  Instantiate(wall, wall.transform.position, Quaternion.identity);
                Destroy(wall);
                Debug.Log("2");
            }
        }
        wallsDestroyed = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (wallsDestroyed && other.CompareTag("Wall"))
        {
            Destroy(other.gameObject);
            Debug.Log("3");
        }
    }
}