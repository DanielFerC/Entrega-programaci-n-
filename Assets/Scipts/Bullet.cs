using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int puntosDeDano;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int darPuntosDeDano()
    {
        return puntosDeDano;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;

        string etiqueta = objeto.tag;

        Destroy(this.gameObject);
        
    }
}
