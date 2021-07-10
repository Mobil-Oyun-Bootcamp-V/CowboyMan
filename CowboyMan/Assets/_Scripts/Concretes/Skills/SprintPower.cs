using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintPower:MonoBehaviour
{
    PlayerController _playerController;
    SkillManager _skillManager;
    float firstSpeedPlayer;
    public SprintPower(PlayerController playerController, SkillManager skillManager, float firstSpeed)
    {
        _playerController = playerController;
        firstSpeedPlayer = firstSpeed;
        _skillManager = skillManager;

        GameManager.Instance.OnIsWalking += WalkingActivated;
        GameManager.Instance.OnIsRunning += SprintActivated;
        GameManager.Instance.OnIsSuperRunning += SuperSprintActivated;
        GameManager.Instance.OnIsDead += StopActivated;
        GameManager.Instance.OnIsWin += StopActivated;
    }
    //Skillerimizin karakterin hýzýný ne kadar arttýracaðýný kontrol ettiðimiz yer.

    void WalkingActivated()
    {
        _playerController.verticalSpeed = firstSpeedPlayer;
    }
    void SprintActivated()
    {
        _playerController.verticalSpeed =_skillManager.SprintBonus;
    }
    void SuperSprintActivated()
    {
        _playerController.verticalSpeed = _skillManager.SuperSprintBonus;
    }
    void StopActivated()
    {
        _playerController.verticalSpeed = 0;
    }
    
}
   
