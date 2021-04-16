using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_gameover : MonoBehaviour
{

    GameObject Player;

    GameControl gmc;

    //private void Start()
    //{
    //    Player= GameObject.Find("Player_2D ");
    //    gmc = Player.GetComponent<GameControl>();
    //}

    //衝突判定
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "danmaku")
        {
            SceneManager.LoadScene("Result");
            //Destroy(this.gameObject);
        }
    }
}
