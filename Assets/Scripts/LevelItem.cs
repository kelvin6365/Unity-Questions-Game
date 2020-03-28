﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{

    [SerializeField] public Text LevelText;
    [SerializeField] public Text LevelText2;
    [SerializeField] public GameObject LockObject;
    [SerializeField] public GameObject ActiveObject;

    [SerializeField] public Image Start_1;
    [SerializeField] public Image Start_2;
    [SerializeField] public Image Start_3;

    [SerializeField] public Sprite ActiveStart;
    [SerializeField] public Sprite UnActiveStart;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(int LevelId, string QuestionType)
    {

        LevelText.text = LevelId.ToString();
        LevelText2.text = LevelId.ToString();
        Debug.Log(PlayerPrefs.GetInt(QuestionType + "_LevelState"));
        Debug.Log(PlayerPrefs.GetInt(QuestionType + "_Level_" + LevelId.ToString() + "_State"));
        if (PlayerPrefs.GetInt(QuestionType + "_LevelState") >= LevelId || (PlayerPrefs.GetInt(QuestionType + "_LevelState") == 0 && LevelId == 1))
        {
            ActiveObject.SetActive(true);
            LockObject.SetActive(false);
            var LevelState = PlayerPrefs.GetInt(QuestionType + "_Level_" + LevelId.ToString() + "_State");
            Debug.Log(QuestionType + "_[Level_" + LevelId.ToString() + "] LevelState:" + LevelState.ToString());
            switch (LevelState)
            {
                case 1:
                    Start_1.sprite = ActiveStart;
                    break;
                case 2:
                    Start_1.sprite = ActiveStart;
                    Start_2.sprite = ActiveStart;
                    break;
                case 3:
                    Start_1.sprite = ActiveStart;
                    Start_2.sprite = ActiveStart;
                    Start_3.sprite = ActiveStart;
                    break;
                default: Debug.Log("[Level_" + LevelId.ToString() + "] not played yet"); break;
            }
            this.gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                this.gameObject.GetComponent<changeScene>().LoadLevelScene(LevelId, QuestionType);
            });
        }
        else
        {
            ActiveObject.SetActive(false);
            LockObject.SetActive(true);
        }
        //  var   LevelState = PlayerPrefs.GetInt("LevelState");
        //  if(LevelState)
    }
}
