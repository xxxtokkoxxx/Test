using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Element
{    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "block")
        {
            Destroy(gameObject);//знищення сфери
            Destroy(collision.gameObject);//знищуєм блок
            App.playerModel.winCount += 1;//кількість знищених блоків для переходу на новий рівень
            App.playerController.BallAppear();//оновлення сфери
            App.playerViev.ballRb = App.playerViev.ball.GetComponent<Rigidbody>();//перегружаєм фізику в префаба
            Debug.Log(App.playerModel.winCount);

            if (App.playerModel.winCount > 2)
            {
                App.playerController.BlockAppear();//оновлюєм блоки
            }
        }

        if(collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);//знищення сфери
            App.playerController.BallAppear();//оновлення сфери
            App.playerViev.ballRb = App.playerViev.ball.GetComponent<Rigidbody>();//перегружаєм фізику в префаба
        }
    }
}
