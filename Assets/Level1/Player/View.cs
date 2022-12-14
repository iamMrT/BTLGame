using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject controller;
    public GameObject attackController;
    PlayerAttack m_attack;
    public float move;


    void Start()
    {
        m_attack = FindObjectOfType<PlayerAttack>();
    }
    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Vertical");

        if (move > 0f)
        {
            controller.GetComponent<mvcControll>().moveRight();
        }
        else if (move < 0f)
        {
            controller.GetComponent<mvcControll>().moveLeft();
        }

        if (jump > 0 || Input.GetKey(KeyCode.Space))
        {
            controller.GetComponent<mvcControll>().moveUp();
        }
        if (Input.GetKey(KeyCode.Z) || Input.GetMouseButton(0))
        {
            
            m_attack.CanAttack();
        }
        else if (jump < 0)
        {
            controller.GetComponent<mvcControll>().moveDown();
        }


    }
}
