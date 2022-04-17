using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pontuacao : MonoBehaviour
{
    public int pontuacaoTotal;
   

    public static Pontuacao instance;
    public Text pontuacaotext;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void UpdateText()
    {
        pontuacaotext.text = pontuacaoTotal.ToString();
    }

    public void MostrarGameOver()
    {
       gameOver.SetActive(true);
    }

    public void Recomecar(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}
