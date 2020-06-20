using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : Element
{
    public Vector3 playerStartPos;// старотова позиція
    public Vector3 playerCurrentPos;//поточна позиція
    public Vector3 mousePos;//позиція курсора/пальця
    public Vector3 prefabStartPos;//стартова позиція м'яча
    public Vector3 force;//сила * напрямок * різниця
    public Vector3 direction;//напрямок
    public Vector3 ballCurrentPos;//поточна поз сфери

    public Vector2 startMousePos;
    public Vector2 currentMousePos;

    public Vector3 blockStartPos_1, blockStartPos_2, blockStartPos_3;// старторві позиції префабу

    public float playerSpeed;//швидкість для слідування за пальцем
    public float power;// сила запуску сфери
    public float distance;// різниця поточої поз від стартової поз player

    public int winCount;//кількість знищених блоків
    public int levelCount;//номер рівня

    public bool win;//переммінна, яка перевіряє зіткнення зі стіною

    [HideInInspector]
    public Transform target;// ціль для методу LookAt()
}
