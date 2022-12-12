using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mvcControll : MonoBehaviour
{
     model m_model;
     View m_view;
     public float move;
    void Start()
    {
     m_model = FindObjectOfType<model>();
     m_view = FindObjectOfType<View>();
    }  
    public GameObject model;
    private GameObject View;


     void Update()
    {
        // set animation
        move =  Input.GetAxis("Horizontal"); // lay phim
        m_model.setBool("Run" , move !=0);
        m_model.setBool("grounded", model.GetComponent<model>().isGrounded());
    }

    public void moveRight () {
        if(model.GetComponent<model>().wallJumpCooldown < 0.2f) {
         model.GetComponent<model>().transform.Translate(Vector2.right * model.GetComponent<model>().speed * Time.deltaTime);
         
        // doi huong nhan vat
        model.GetComponent<model>().transform.localScale = new Vector3(1,1,1);

         if(!model.GetComponent<model>().isGrounded() && model.GetComponent<model>().onWall() ){
              model.GetComponent<model>().body.gravityScale = 0;
              model.GetComponent<model>().body.velocity = Vector2.zero;
            }
            else {
                 model.GetComponent<model>().body.gravityScale = 3;
            }
        }
         else {
           model.GetComponent<model>().wallJumpCooldown += Time.deltaTime;
        }
    }

    public void moveLeft () {
        if(model.GetComponent<model>().wallJumpCooldown < 0.2f) {
        model.GetComponent<model>().transform.Translate(Vector2.left * model.GetComponent<model>().speed * Time.deltaTime);

        // doi huong nhan vat
        model.GetComponent<model>().transform.localScale = new Vector3(-1,1,1);
        }
         else {
           model.GetComponent<model>().wallJumpCooldown += Time.deltaTime;
        }
    }

     public void moveUp () {
        if( model.GetComponent<model>().wallJumpCooldown < 0.2f) {
            model.GetComponent<model>().transform.Translate(Vector2.up * model.GetComponent<model>().jump * Time.deltaTime);

        // wall logic
            if(!model.GetComponent<model>().isGrounded() && model.GetComponent<model>().onWall() ){
              model.GetComponent<model>().body.gravityScale = 0;
              model.GetComponent<model>().body.velocity = Vector2.zero;
            }
            else {
                 model.GetComponent<model>().body.gravityScale = 4;
            }

        //  if(model.GetComponent<model>().isGrounded()) {
            
        //  }
        if (!model.GetComponent<model>().isGrounded() && model.GetComponent<model>().onWall() ){
            if(move == 0 ){
            model.GetComponent<model>().body.velocity = new Vector2(-Mathf.Sign(model.GetComponent<model>().transform.localScale.x ) *10, 0);
            model.GetComponent<model>().transform.localScale = new Vector3(-Mathf.Sign(model.GetComponent<model>().transform.localScale.x ),model.GetComponent<model>().transform.localScale.y,model.GetComponent<model>().transform.localScale.z );
            }
             else 
            model.GetComponent<model>().body.velocity = new Vector2(-Mathf.Sign (model.GetComponent<model>().transform.localScale.x ) *3, 2);

            model.GetComponent<model>().wallJumpCooldown = 0;
           }

        }
        else {
           model.GetComponent<model>().wallJumpCooldown += Time.deltaTime;
        }
    }
     public void moveDown () {
        model.GetComponent<model>().transform.Translate(Vector2.down * model.GetComponent<model>().speed * Time.deltaTime);
    }

    public bool  canAttack() {
        return  View.GetComponent<View>().move == 0 && model.GetComponent<model>().isGrounded() && !model.GetComponent<model>().onWall(); 
    }

} 
