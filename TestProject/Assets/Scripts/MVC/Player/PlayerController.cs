using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Element
{
    private Camera _cam;
    private GameObject _block;//obj для ініціалізація префабу

    private void Awake()
    {
        _cam = Camera.main;//ініціалізація камери
        App.playerViev.ball = Instantiate(App.playerViev.ball, App.playerModel.prefabStartPos, Quaternion.identity);
        App.playerModel.win = false;
    }

    private void Update()
    {
        Ray();//зчитуєм координати курсора

        App.playerModel.ballCurrentPos = App.playerViev.ball.transform.position;//позиція сфери
        App.playerModel.playerCurrentPos = App.playerViev.player.transform.position;//оновлюєм дані щодо поточної позиції гравця
        App.playerModel.target = App.playerViev.player.transform;//ціль для метода LookAt()
    }

    public void BallAppear()//виклик префабу м'яча
    {
        App.playerViev.ball = Instantiate(App.playerViev.ball, App.playerModel.prefabStartPos, Quaternion.identity);
        App.playerViev.playerCol.enabled = true;//вмикаєм колайдер після зіткнення
    }

    public void Drag()//метод слідування за курсором/пальцем
    {
        App.playerViev.playerRb.transform.position = Vector3.Lerp(App.playerViev.playerRb.transform.position,
             App.playerModel.mousePos,
             Time.deltaTime * App.playerModel.playerSpeed);
        App.playerViev.ball.transform.LookAt(App.playerModel.target.transform.position, Vector3.forward);
    }

    public void PushBall()//метод запуску сфери
    {
        App.playerModel.distance = Vector3.Distance(App.playerModel.playerStartPos, App.playerModel.playerCurrentPos);
        App.playerModel.direction = App.playerModel.playerStartPos - App.playerModel.playerCurrentPos;
        App.playerModel.force = App.playerModel.direction * App.playerModel.distance * App.playerModel.power;

        App.playerViev.ballRb.AddForce(App.playerModel.force, ForceMode.Force);
    }

    public void Win()//метод переходу на новий рівень
    {
        if (App.playerModel.winCount >= 3)
        {
            App.playerModel.levelCount += 1;
            App.playerModel.win = true;
            App.playerModel.winCount = 0;
            Debug.Log("Level Up");
        }
    }

    public void BlockAppear()//виклик блоків
    {
        _block = Instantiate(App.playerViev.block, App.playerModel.blockStartPos_1, Quaternion.identity);
        _block = Instantiate(App.playerViev.block, App.playerModel.blockStartPos_2, Quaternion.identity);
        _block = Instantiate(App.playerViev.block, App.playerModel.blockStartPos_3, Quaternion.identity);
    }
  /*  public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[10];
        App.playerViev.lineRenderer.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time;
        }
        App.playerViev.lineRenderer.SetPositions(points);
    }*/

    //---------------------------------------------------

    private void Ray()//зчитування координат курсора
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Transform objectHit = hit.transform;
            App.playerModel.mousePos.x = hit.point.x;
            App.playerModel.mousePos.y = hit.point.y;
            App.playerModel.mousePos.z = hit.point.z;
            App.playerModel.mousePos = new Vector3(App.playerModel.mousePos.x, 0, App.playerModel.mousePos.z);// y = 0 для уникнення зміни висоти об'єкта
        }
        LimitOfMovement(4f, 1f, -4f, -7f);//метод встановлення меж, які обмежують рух об'єкта за курсором, в якості параметрів вказані самі межі
    }

    //метод встановлення меж, які обмежують рух об'єкта за курсором, в якості параметрів вказані самі межі
    private void LimitOfMovement(float limitPositiveX, 
        float limitPositiveZ, 
        float limitNegativeX,
        float limitNegativeZ)
    {
        if(App.playerViev.player.transform.position.x > limitPositiveX)
        {
            App.playerViev.player.transform.position = new Vector3(limitPositiveX,
                App.playerViev.player.transform.position.y,
                App.playerViev.player.transform.position.z);
        }

        if (App.playerViev.player.transform.position.z > limitPositiveZ)
        {
            App.playerViev.player.transform.position = new Vector3(App.playerViev.player.transform.position.x,
                App.playerViev.player.transform.position.y,
                limitPositiveZ);
        }

        if (App.playerViev.player.transform.position.x < limitNegativeX)
        {
            App.playerViev.player.transform.position = new Vector3(limitNegativeX,
                App.playerViev.player.transform.position.y,
                App.playerViev.player.transform.position.z);
        }

        if (App.playerViev.player.transform.position.z < limitNegativeZ)
        {
            App.playerViev.player.transform.position = new Vector3(App.playerViev.player.transform.position.x,
                App.playerViev.player.transform.position.y,
                limitNegativeZ);
        }
    }
}
