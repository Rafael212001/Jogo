using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Pego do canal Crie Seus jogos https://www.youtube.com/channel/UCXxkw9HWPVXVZsi1oTVvKCQ

public class Coletaveis : MonoBehaviour
{
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Pontuacao.instance.pontuacaoTotal += Score;
            Pontuacao.instance.UpdateText();
            Destroy(gameObject);
        }
    }
}
