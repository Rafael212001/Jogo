using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Sala de aula 
public class Vida : MonoBehaviour
{
    // Start is called before the first frame update

    public int vidaAtual;
    public int vidaTotal = 10;
    public Image vidaImagem;
    void Start()
    {
        vidaAtual = vidaTotal;
    }

    // Update is called once per frame


    void Update()
    {
        
    }
    private void VidaMaxima()
    {
        vidaImagem.fillAmount = vidaAtual / vidaTotal;
        //helthSlider.size = vidaAtual / vidaTotal;
    }
}
