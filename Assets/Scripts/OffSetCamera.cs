using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffSetCamera : MonoBehaviour
{
    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    //se o player encostar na parte de baixo da tela, aciona o evento de morte;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !Player.isDead)
        {
            player.som.OnDeath();
            player.OnDeath?.Invoke();
        }
    }
}
