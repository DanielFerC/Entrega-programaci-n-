using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bala;
    [SerializeField] GameObject balaRafaga;
    [SerializeField] GameObject disparador;
    [SerializeField] GameObject balaCamaralenta;
    [SerializeField] float fireRate;


    float minX,maxX,minY,maxY;
    float nextFire=0;
    float nextRafaga = 0;
    float nextCamaraLenta = 0;
    bool cambiarBala = true;
    bool balaCamaraLenta = false;
    int usosCamaraLenta = 3;
    float contador = 0;
    
   

    // Start is called before the first frame update
    void Start()
    {
        new Vector2(1, 1);
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 puntoMinParaY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.7f));

        maxX = esquinaSupDer.x - 0.7f;
        maxY = esquinaSupDer.y - 0.7f;
        minX = puntoMinParaY.x + 0.7f;
        minY = puntoMinParaY.y;

        

        // World space = el espacio del juego
        // screen space = la resolución
        // viewport = la camara 


    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
       
       
        
        if (balaCamaraLenta == true)
        {
            DispararCamaralenta();

        }

        if (cambiarBala)
            Disparar();
        else
            DispararRafaga();


        if (Input.GetKeyDown(KeyCode.Z))
        {
            cambiarBala = cambiarBala ? false : true;
        }


        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextCamaraLenta && usosCamaraLenta >= 1)
        {

            (GameObject.Find("GameManager").GetComponent<GameManager>()).Realentizar();

            balaCamaraLenta = true;
           
            nextCamaraLenta = Time.time + 5;
            usosCamaraLenta = usosCamaraLenta-1;
            contador = Time.time;
           
        }
        if (Time.time >= contador+3)
        {
            (GameObject.Find("GameManager").GetComponent<GameManager>()).Normalizar();
            balaCamaraLenta = false;
            System.Diagnostics.Debug.WriteLine(" tiempo",Time.time);
        }

           


    }
    void DispararCamaralenta()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(balaCamaralenta, disparador.transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }



    }
    void DispararRafaga()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextRafaga)
        {
            
            Instantiate(balaRafaga, disparador.transform.position, transform.rotation);
            nextRafaga = Time.time + (fireRate/3);
        }

    }
    void Disparar()
    {
        
        
        if(Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(bala, disparador.transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }

    }
    void MoverNave()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movH * Time.deltaTime * speed, movV * Time.deltaTime * speed);


        transform.Translate(movimiento);

        // verificar la posición
        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.x < minX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }
    }






}


