using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Cores
{
    Amarelo,
    Azul,
    Vermelho,
    Roxo
}
public class Player : MonoBehaviour
{
    //Fisica
    public Rigidbody2D myRigidbody2D;
    public float pushForce;

    //Cor
    public static Cores cores;
    public  Color amarelo, vermelho, azul, roxo;
    private SpriteRenderer spriteRenderer;

    //eventos
    public Action OnStarCollision;
    public UnityEvent OnDeath;
    public Action<int> OnChangeColor;
    public static bool isDead;

    //particulas
    public GameObject deathParticle, starParticle;
    public ParticleSystem particle;

    //Som
    public Som som;
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = amarelo;

        isDead = false;

        //cria uma pool das particulas
        PoolManager.WarmPool(deathParticle, 4);
        PoolManager.WarmPool(starParticle, 4);
        PoolManager.WarmPool(particle.gameObject, 4);
    }


    void Update()
    {
        //movimentação do player
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            myRigidbody2D.isKinematic = false;
            myRigidbody2D.velocity = Vector2.zero;
            myRigidbody2D.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
            som.OnSound(som.touch);
        }

        //troca a cor do player baseado no enum
        switch (cores)
        {
            case Cores.Amarelo:
                spriteRenderer.color = amarelo;
                break;
            case Cores.Azul:
                spriteRenderer.color = azul;
                break;
            case Cores.Vermelho:
                spriteRenderer.color = vermelho;
                break;
            case Cores.Roxo:
                spriteRenderer.color = roxo;
                break;
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //se enconstar na estrela, chama o evento, spawna a particula da estrela e da release na estrela
        if (other.CompareTag("Estrela") && !isDead)
        {
            som.OnSound(som.star);
            OnStarCollision?.Invoke();
            PoolManager.SpawnObject(starParticle, other.transform.position, Quaternion.identity);
            PoolManager.ReleaseObject(other.gameObject);
        }
    }
}
