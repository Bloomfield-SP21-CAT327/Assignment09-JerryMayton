using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public int level;
    public int experience;
    public int currentLevel;
    public PlayerData(Player player)
    {
        level = player.level;
        experience = player.experience;
        currentLevel = player.currentLevel;
    }
}
