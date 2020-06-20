using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public App App {get
        { return FindObjectOfType<App>(); }//надаєм доступ до App
    }
}
