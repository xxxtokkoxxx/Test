using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Element
{
    private void Start()
    {
        App.enemyModel.enemyStartPos = App.enemyViev.enemy.transform.position;
    }
    public void CatchBall()//слідування за сферою
    {
        Vector3 pos = new Vector3(App.playerModel.ballCurrentPos.x,
            App.enemyModel.enemyStartPos.y,
            App.enemyModel.enemyStartPos.z);
        App.enemyViev.enemyRb.transform.position = Vector3.Lerp(App.enemyViev.enemyRb.transform.position, pos, Time.deltaTime);
        LimitMovement();
        SpeedUp();
    }

    private void LimitMovement() //метод встановлення меж, які обмежують рух об'єкта за сферою

    {
        if (App.enemyViev.enemy.transform.position.x < -7.17f)
        {
            App.enemyViev.enemy.transform.position = new Vector3(-7.17f, App.enemyModel.enemyStartPos.y, App.enemyModel.enemyStartPos.z);
        }

        if (App.enemyViev.enemy.transform.position.x > 6.27f)
        {
            App.enemyViev.enemy.transform.position = new Vector3(6.27f, App.enemyModel.enemyStartPos.y, App.enemyModel.enemyStartPos.z);
        }

        if (App.enemyViev.enemy.transform.position.x < App.playerModel.ballCurrentPos.x)// задажться для точного руху enemy за сферою
        {
            App.enemyViev.enemy.transform.position = new Vector3(App.playerModel.ballCurrentPos.x * App.enemyModel.speed, App.enemyModel.enemyStartPos.y, App.enemyModel.enemyStartPos.z);
        }

        if (App.enemyViev.enemy.transform.position.x > App.playerModel.ballCurrentPos.x)
        {
            App.enemyViev.enemy.transform.position = new Vector3(App.playerModel.ballCurrentPos.x * App.enemyModel.speed, App.enemyModel.enemyStartPos.y, App.enemyModel.enemyStartPos.z);
        }
    }

    private void SpeedUp()//збільшення швидкості з кожним рівнем
    {
        if (App.playerModel.win == true)
        {
            App.enemyModel.speed += 0.1f;
            App.playerModel.win = false;
            Debug.Log("winnnnn");
        }
    }
}
