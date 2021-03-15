using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pontuação : MonoBehaviour
{
    int pontos;
    public Text currentPontos, pontosDeath;
    public Text bestScoreText;
    public Player player;
    int bestScore;
    public GameObject lose;


    //da load nas variaveis salvas e inscreve os metodos nos eventos
    private void Start()
    {
        Load();
        player.OnStarCollision += UpdatePontos;
        player.OnDeath.AddListener(Dead);
    }

    void UpdatePontos()
    {
        pontos++;
        currentPontos.text = pontos.ToString();
        Save();
    }

    void Dead()
    {
        Player.isDead = true;
        StartCoroutine(onDeathPlayer());
    }
    void Save()
    {
        if (pontos > PlayerPrefs.GetInt("BestScore"))
            PlayerPrefs.SetInt("BestScore", pontos);

    }
    void Load()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
    }

    //instancia a particula, desativa o player e quando acabar animação da particula ele ativa a tela de Lose;
    IEnumerator onDeathPlayer()
    {
        
        PoolManager.SpawnObject(player.deathParticle, player.transform.position, Quaternion.identity);
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        bestScoreText.text = bestScore.ToString();
        pontosDeath.text = pontos.ToString();
        lose.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        
    }
}
