using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugProject : MonoBehaviour
{
    public NinjaStateManager stateManager;
    public Image[] stateImage;
    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = stateImage[0].color;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        UpdateStateImageColor();
    }

    void UpdateStateImageColor()
    {
        foreach (var image in stateImage)
        {
            image.color = defaultColor; 
        }

        if (stateManager.currentNinjaState is IdleState)
        {
            stateImage[0].color = Color.red;
        }
        else if (stateManager.currentNinjaState is RunState)
        {
            stateImage[1].color = Color.red;
        }
        else if (stateManager.currentNinjaState is JumpState)
        {
            stateImage[2].color = Color.red;
        }
        else if (stateManager.currentNinjaState is AttackState)
        {
            stateImage[3].color = Color.red;
        }
        else if (stateManager.currentNinjaState is HurtState)
        {
            stateImage[4].color = Color.red;
        }
        else if (stateManager.currentNinjaState is DieState)
        {
            stateImage[5].color = Color.red;
        }
    }

    public void ChangeState(int state)
    {
        switch (state)
        {
            case 0:
                stateManager.SelectState(stateManager.idleState);
                break;
            case 1:
                stateManager.SelectState(stateManager.runState);
                break;
            case 2:
                stateManager.SelectState(stateManager.jumpState);
                break;
            case 3:
                stateManager.SelectState(stateManager.attackState);
                break;
            case 4:
                stateManager.SelectState(stateManager.hurtState);
                break;
            case 5:
                stateManager.SelectState(stateManager.dieState);
                break;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
