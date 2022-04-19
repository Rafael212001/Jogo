using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public float fallGravityScale = 3.0f;
    public LayerMask groundLayer;
    public float radius = 10.0f;
    public Vector3 offset;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int GroundedHash = Animator.StringToHash("Grounded");

    private Vector2 _moviment = Vector2.zero;
    private bool _isJumping = false;
    private bool _isGrounded = false;

    // Awake is called when the script instance is being loaded
    // Renderiza antes do jogo começar
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        //playerState.Initialize();
    }


    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instace.LoadScene("");
    }

    // Update is called once per frame
    void Update()
    {
        // Capturamos o valor de input do jogador no eixo horizontal.
        float inputX = Input.GetAxisRaw("Horizontal");
        // Criamos o vetor de movimento de acordo com o input.
        _moviment = new Vector2(inputX, 0.0f) * speed;
        // flipamos a imagem de acordo com a direcao do controle.
        if (_moviment.sqrMagnitude > 0.1f)
            _spriteRenderer.flipX = !(inputX > 0.1f);

        // Atualiza variavel de estado de salto.
        if (!_isJumping)
            _isJumping = Input.GetButtonDown("Jump");

        // Atualiza parametro na maquina de estados de animacao.
        _animator.SetFloat(SpeedHash, Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetBool(GroundedHash, _isGrounded);
    }

    //recomendada quando queremos gerenciar principalmente componentes de física
    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(this.transform.position + offset,
                                                            radius, groundLayer);

        if (_moviment.sqrMagnitude > 0.0f &&
            Mathf.Abs(_rigidbody.velocity.y) < 0.01f)
        {
            _rigidbody.AddForce(_moviment, ForceMode2D.Force);
        }

        if (_isJumping && _isGrounded)
        {
            _isJumping = false;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (_rigidbody.velocity.y < -0.01f)
        {
            _rigidbody.gravityScale = fallGravityScale;
        }
        else
        {
            if (_rigidbody.gravityScale > 2.0f)
                _rigidbody.gravityScale = 2.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Damage"))
        {
            //playerState.TakeHit();
        }
        //cerca
        if (collision.gameObject.tag == "Cerca")
        {
            //Debug.Log("Cercaa");
            Pontuacao.instance.MostrarGameOver();
            Destroy(gameObject);
            
        }
        //cerca
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cerca")
        {
            //Debug.Log("Cercaa");
            Pontuacao.instance.MostrarGameOver();
            Destroy(gameObject);

        }
        //cerca
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position + offset, radius);
    }
}
