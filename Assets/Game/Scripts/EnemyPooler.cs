using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;
    private Queue<GameObject> objectPool = new Queue<GameObject>();
    public Vector3[] spawnPositions;
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InitializeEnemyPool(player);
    }

    private void InitializeEnemyPool(Transform player)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, spawnPositions[i],
            quaternion.identity);
            obj.SetActive(true);
            EnemyDetectAndMovement enemy = obj.GetComponent<EnemyDetectAndMovement>();
            enemy.patrolPoints = new Vector3[4];
            StartCoroutine(RandomizeEnemyPosition(enemy));
            enemy.player = player;
            objectPool.Enqueue(obj);
        }
    }

    IEnumerator RandomizeEnemyPosition(EnemyDetectAndMovement enemy)
    {
        while (true)
        {
            RandomizeEnemyPositionLoop(enemy);
            yield return new WaitForSeconds(30f);

        }
    }

    void RandomizeEnemyPositionLoop(EnemyDetectAndMovement enemy)
    {
        for (int j = 0; j < enemy.patrolPoints.Length; j++)
        {
            int randomInt = UnityEngine.Random.Range(1, 5);
            enemy.patrolPoints[0] = new Vector3(enemy.transform.position.x - randomInt, enemy.transform.position.y - randomInt, 0);
            enemy.patrolPoints[1] = new Vector3(enemy.transform.position.x + randomInt, enemy.transform.position.y + randomInt, 0);
            enemy.patrolPoints[2] = new Vector3(enemy.transform.position.x + randomInt, enemy.transform.position.y - randomInt, 0);
            enemy.patrolPoints[3] = new Vector3(enemy.transform.position.x - randomInt, enemy.transform.position.y + randomInt, 0);
        }
    }
    // Verifica se há objetos na fila. Se houver, ele remove e retorna
    // o primeiro objeto da fila.
    public GameObject GetPooledObject()
    {
        if (objectPool.Count > 0)
        {
            GameObject obj = objectPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        // Se a fila estiver vazia, pode-se optar por aumentar 
        // a piscina ou lidar com isso de acordo com a lógica do seu jogo.
        return null;
    }

    // Desativa o objeto e o enfileira de volta, pronto para ser reutilizado.
    public void ReturnPooledObject(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }
}
