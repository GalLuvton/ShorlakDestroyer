using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;


    // Use this for initialization
    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    
    private void EndGame()
    {
        Application.Quit();
    }

    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.EndGame();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
    
}
