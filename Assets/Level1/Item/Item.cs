using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    model m_model;
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Player")){

            m_model.IncrementScore();
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        m_model =FindObjectOfType<model>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
