using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] int puntosDeVida;
    
    float minX;
    float maxX;
    
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;


    }

    // Update is called once per frame
    void Update()
    {
       
        if (movingRight)
        {
            Vector2 movimiento = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        else
        {
            Vector2 movimiento = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        if(transform.position.x >= maxX)
        {
            // que se mueva a la izq
            movingRight = false;
        }
        else if(transform.position.x <= minX)
        {
            // que se mueva a la der
            movingRight = true;
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Disparo"))
        {

            int puntos = collision.gameObject.GetComponent<Bullet>().darPuntosDeDano();
            puntosDeVida = puntosDeVida - puntos;

            if (puntosDeVida < 1)
            {
                (GameObject.Find("GameManager").GetComponent<GameManager>()).CaptureAnimal();
                Destroy(this.gameObject);
            }
              
              
        }
    }
}
