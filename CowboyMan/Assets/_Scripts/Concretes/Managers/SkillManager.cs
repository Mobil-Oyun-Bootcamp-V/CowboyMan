using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillManager : MonoBehaviour
{
    PlayerController _playerController;
    SprintPower _sprintPower;
    GameObject Player;
    GameObject ActiveSkills;

    [field: Header("SprintOptions")]
    [field: SerializeField] public float SprintBonus { get; private set; }
    [field: SerializeField] public float SuperSprintBonus { get; private set; }
    void Awake()
    {   
        _playerController = GameObject.FindObjectOfType<PlayerController>();

        Player = _playerController.gameObject;
        ActiveSkills = Player.transform.GetChild(Player.transform.childCount - 1).gameObject;

        _sprintPower = new SprintPower(_playerController,this,_playerController.verticalSpeed);
    }
    void OnEnable()
    {
        GameManager.Instance.OnIsWalking += Walking;
        GameManager.Instance.OnIsRunning += Running;
        GameManager.Instance.OnIsSuperRunning += SuperRunning;
        GameManager.Instance.OnIsWin += Win;
        GameManager.Instance.OnIsDead += Dead;
    }
    void OnDisable()
    {
        GameManager.Instance.OnIsWalking -= Walking;
        GameManager.Instance.OnIsRunning -= Running;
        GameManager.Instance.OnIsSuperRunning -= SuperRunning;
        GameManager.Instance.OnIsWin -= Win;
        GameManager.Instance.OnIsDead -= Dead;
    }
    //Karakterin altýnda çýkan skillerin gösteriminin yapýldýðý class.
    void Walking()
    {
        ActiveMod(0);
    }
    void Running()
    {
        ActiveMod(1);
    }
    void SuperRunning()
    {
        ActiveMod(2);
    }
    void Dead()
    {
        ActiveMod(3);
    }
    void Win()
    {
        ActiveMod(4);
    }

    void ActiveMod(int saveSkill)
    {
        for(int i = 0; i < ActiveSkills.transform.childCount; i++)
        {
            if (i == saveSkill) 
            {
                ActiveSkills.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                ActiveSkills.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }






}
