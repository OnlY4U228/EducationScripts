using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    //Done
    public SaveLoadSystem ScoreTest;
    public int Price = 10;
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            ScoreTest.Score += Price;
            this.gameObject.SetActive(false);
        }       
    }
}
