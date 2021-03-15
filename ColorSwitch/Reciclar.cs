using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciclar : MonoBehaviour
{
    private Player player;

    private void OnEnable()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(SlowUpdate());
    }

    //quando a altura do item  + offset for menor q a altura do player, ele recicla o objeto; 
    IEnumerator SlowUpdate()
    {
        while (true)
        {
                if (transform.position.y + 10 < player.transform.position.y && !Player.isDead)
                {
                    PoolManager.ReleaseObject(gameObject);

                }
                

            yield return new WaitForSeconds(0.2f);
        }

    }
}
