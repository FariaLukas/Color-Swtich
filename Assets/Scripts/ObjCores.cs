using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCores : MonoBehaviour
{
    public Cores cor;
    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //se colidir com o player e tiver cor diferente dele, chama o evento de morrer;
        if (other.CompareTag("Player") && !Player.isDead)
        {
            if (Player.cores == cor)
            {
                
            }
            else
            {
                player.som.OnDeath();
                player.OnDeath?.Invoke();
            }
        }
    }
}
