using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
   public Text scoreText;
    
   public void SetScoreText(string txt){
     if(scoreText)
     scoreText.text = txt;
   }
}
