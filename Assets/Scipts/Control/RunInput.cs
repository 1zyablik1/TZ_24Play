using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunInput : IControlable
{
    private Player player;

    private float theHalfOfRoad;
    private int screenWidth;
    private int screenHalf;

    private float moveMultiply = 1;
    private float moveXPos = 0;
    private float roadInputOffset = 0.4f;
    private float halfPlayerOffset = 1f;
    private float roadBorder;

    public RunInput()
    {
        theHalfOfRoad = (SettingsManager.settings.roadWidth - roadInputOffset) / 2.0f;
        screenWidth = Screen.width;
        screenHalf = screenWidth / 2;
        moveMultiply = theHalfOfRoad / (float)screenHalf;
        roadBorder = (SettingsManager.settings.roadWidth - halfPlayerOffset) / 2.0f;

        player = PlayerManager.GetPlayerGameObj().GetComponent<Player>();
    }

    public void ControlInput()
    {
        if(Input.GetMouseButton(0))
        {
            CalculateXPos();
            player.posX.x = moveXPos;
        }
    }

    private void CalculateXPos()
    {
        int mousePosX = (int)Input.mousePosition.x;
        int temp = screenWidth - mousePosX;
        if (screenHalf >= temp)//r
        {
            moveXPos = (mousePosX - screenHalf) * moveMultiply;
        }
        else if (screenHalf < temp)//l
        {
            moveXPos = (screenHalf - mousePosX) * moveMultiply * -1;
        }

        moveXPos = Mathf.Clamp(moveXPos, -1 * roadBorder, roadBorder);
    }
}
