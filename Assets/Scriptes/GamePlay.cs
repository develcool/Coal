﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public int deltaHP = 2;
    public int minutes;
    public float seconds;
    public float timeInSecods;
    [SerializeField] private Slider bar;
    [SerializeField] private Text hpText;
    [SerializeField] private GameObject woodPref;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("setDeltaHP",10f,10f);
        InvokeRepeating("minusHP",2f,2f);
        InvokeRepeating("spawnWood", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        timeInSecods = Mathf.Round(timer.timeByGame);
        bar.value = MainScript.FireHP;
        hpText.text = "Fire HP = " + MainScript.FireHP;
        if(MainScript.FireHP <= 0)
        {
            hpText.text = "Game Over!";
            MainScript.isAliev = false;
        }

        Debug.Log("=============================================================");
        Debug.Log("deltaHp= "+deltaHP);
    }
    public void setDeltaHP()
    {
        deltaHP +=2;
    }
    public void minusHP()
    {
        MainScript.FireHP -= deltaHP;
    }
    public void spawnWood()
    {
        if (MainScript.isPicked == false)
        {
            float x = Random.Range(-7.86f, 7.86f);
            Instantiate(woodPref, new Vector2(x, -4.1f), Quaternion.identity);
        }
    }
}