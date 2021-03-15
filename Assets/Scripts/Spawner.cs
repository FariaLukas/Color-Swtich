using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float height;
    public float maxValue;
    public GameObject[] obstaculos;
    void Start()
    {
        maxValue = obstaculos[0].transform.position.y;
        //cria uma pool de todos os prefabs de obstaculos
        for (int i = 0; i < obstaculos.Length; i++)
        {
            PoolManager.WarmPool(obstaculos[i], 5);
        }
     
        StartCoroutine(SlowUpdate());
    }

    IEnumerator SlowUpdate()
    {
        while (true)
        {
            //atualiza o maior valor
            for (int i = 0; i < obstaculos.Length; i++)
            {
                if (obstaculos[i].transform.position.y > maxValue)
                {
                    maxValue = obstaculos[i].transform.position.y;
                }
             
            }

            //se o a altura do spawner for mais q o ultimo obstaculo+distancia entre eles, sorteia um numero e instancia um obstaculo baseado no numero
            if (transform.position.y > maxValue + height && !Player.isDead)
            {
                int random = Random.Range(0, obstaculos.Length);
                GameObject go = PoolManager.SpawnObject(obstaculos[random], new Vector3(obstaculos[random].transform.position.x, maxValue + height, 0), Quaternion.identity);
                maxValue += height;
            }
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
