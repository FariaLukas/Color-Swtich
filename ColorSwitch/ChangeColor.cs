using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Player player;

    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // sorteia um nmr e muda a cor do player baseado no numero sorteado, spawna particula no local desse gameobject e da release nele;
        if (other.CompareTag("Player") && !Player.isDead)
        {
            player.som.OnSound(player.som.changeColor);
            int nmr=Random.Range(0, 4);
            switch (nmr)
            {
                case 0:
                    Player.cores = Cores.Amarelo;                   
                    break;
                case 1:
                    Player.cores = Cores.Azul;                    
                    break;
                case 2:
                    Player.cores = Cores.Vermelho;
                    break;
                case 3:
                    
                    Player.cores = Cores.Roxo;
                    break;

            }
            player.OnChangeColor?.Invoke(nmr);
            PoolManager.SpawnObject(player.particle.gameObject,transform.position, Quaternion.identity);
            PoolManager.ReleaseObject(gameObject);
        }
    }
}
