using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColor : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private Player player;
    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        player = FindObjectOfType<Player>();
        player.OnChangeColor += ChangeColor;
        this.gameObject.SetActive(false);
    }

    //Muda a cor da particula baseado na cor que ele sorteou no ChangeColor
    void ChangeColor(int nmr)
    {
            var main = particle.main;
            switch (nmr)
            {
                case 0:
                    main.startColor = player.amarelo;
                    break;
                case 1:
                    main.startColor = player.azul;
                    break;
                case 2:
                    main.startColor = player.vermelho;
                    break;
                case 3:
                    main.startColor = player.roxo;
                    break;
            }
        print("A");
    }
}
