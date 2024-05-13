using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class GamePointController : MonoBehaviour
{
    public static GamePointController instance;

    public int levelPoint;
    public int actualPoint;
    public int difficulty;
    private int nextUpdate = 1;
    public TMP_Text pointText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
        InvokeRepeating("TimePoint", 0, 1.0f);
    }

    private void Update()
    {
        pointText.text = actualPoint.ToString();

        if (Time.time >= nextUpdate)
        {
            //Debug.Log(Time.time + ">=" + nextUpdate);
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            TimePoint();
        }
    }

    void TimePoint()
    {
        actualPoint += difficulty;
        //Debug.Log("Invoke");
    }

    public void PointNegative(int amount)
    {
        actualPoint -= amount;
    }

    public void PointPositive(int amount)
    {
        actualPoint += amount;
    }
}

