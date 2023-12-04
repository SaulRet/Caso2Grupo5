using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemi_shot : MonoBehaviour
{
    public Transform player_pos;
    public float speed;
    public float distancia_frenado;
    public float distancia_retraso;
    public Transform punto_instancia;
    public GameObject bala;
    private float tiempo;

    void Start()
    {
        player_pos=GameObject.Find("Player").transform;
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        //movimiento
        #region
        if (Vector2.Distance(transform.position, player_pos.position) > distancia_frenado)
        {
            transform.position = Vector2.MoveTowards(transform.position, player_pos.position, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, player_pos.position) < distancia_retraso)
        {
            transform.position = Vector2.MoveTowards(transform.position, player_pos.position, -speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, player_pos.position) < distancia_frenado && Vector2.Distance(transform.position, player_pos.position) > distancia_retraso)
        {
            transform.position = transform.position;
        }
        #endregion
        //flip
        #region
        if(player_pos.position.x>this.transform.position.x)
        {
            this.transform.localScale = new Vector2(1, 1);
        }else
        {
            this .transform.localScale = new Vector2(-1, 1);
        }
        #endregion
        //disparo
        #region
        tiempo += Time.deltaTime;
        if (tiempo >= 2)
        {
            Instantiate(bala,punto_instancia.position,Quaternion.identity);
            tiempo = 0;
        }


    #endregion
    }
    
}
