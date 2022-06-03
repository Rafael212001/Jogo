using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Sala de aula 
[System.Serializable]
public class Vida 
{
    // Start is called before the first frame update

    public int vidaAtual;
    public int vidaTotal = 60;
    public int lives;
    public Image vidaImagem;
 
    void Start()
    {
        lives = vidaTotal;
    }

    // Update is called once per frame

    public void TakeHit()

    {
        Debug.Log("Tomou dano");
        if (vidaAtual > 0)
        {
            vidaAtual -= 30;
            VidaMaxima();

        }
        else
        {
            OnDie();
        }
    }

    public void OnDie()
    {
        if (lives > 0)
        {
            --lives;
            vidaAtual = vidaTotal;
            VidaMaxima();
          
        }
        else{
            Pontuacao.instance.MostrarGameOver();
            GameObject.Destroy(Pontuacao.instance.gameObject);
        }
    }

    void Update()
    {
        
    }
    private void VidaMaxima()
    {
        vidaImagem.fillAmount = vidaAtual / vidaTotal;
        
    }

   
}
