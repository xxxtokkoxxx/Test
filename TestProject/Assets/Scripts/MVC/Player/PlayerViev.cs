using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerViev : Element
{
    public GameObject player;
    public GameObject ball;
    public GameObject block;

    [SerializeField]
    private Text _text;
    [HideInInspector]
    public Rigidbody playerRb;
    [HideInInspector]
    public Rigidbody ballRb;
    [HideInInspector]
    public BoxCollider playerCol;


    private void Start()
    {
        playerCol = player.GetComponent<BoxCollider>();//ініціалізація
        playerRb = player.GetComponent<Rigidbody>();
        ballRb = ball.GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        _text.text = "Level " + App.playerModel.levelCount;//поточний рівень
        App.playerController.Win();//перехід на новий рівень
    }
    private void OnMouseDown()
    {
        App.playerModel.startMousePos = App.playerModel.mousePos;
    }

    private void OnMouseDrag()
    {
        App.playerController.Drag();//слідування об'єкта за курсором/пальцем
    }

    private void OnMouseUp()
    {
        App.playerController.PushBall();// запуск сфери
        playerCol.enabled = false;//вимикакаєм колайдер до моменту зіткнення для уникнення багіз з подвійним натисканням
    }
}
