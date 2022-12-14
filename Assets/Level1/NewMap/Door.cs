using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // [SerializeField] private Transform previousRoom;
    // [SerializeField] private Transform nextRoom;
    // [SerializeField] private CameraController cam;
         model m_model;


     private void OnTriggerEnter2D(Collider2D collision) {
        // camera theo room
        if(collision.tag =="Player"){
              if(m_model.GetScore() >0)   SceneManager.LoadScene("Level3");
               else  SceneManager.LoadScene("Level2");
         
            // if(collision.transform.position.x < transform.position.x) 
            //  cam.MoveToNewRoom(nextRoom);
            //  else
            //  cam.MoveToNewRoom(previousRoom);

        }

 
      }

    // Start is called before the first frame update
    void Start()
    {
             m_model = FindObjectOfType<model>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
