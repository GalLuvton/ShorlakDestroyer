using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [System.Serializable]
    public class EnemyStats
    {
        private int maxHealth = 100;
        [SerializeField]
        private int curHealth;
        public int CurHealth
        {
            get { return curHealth; }
            set { curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        
        public void Init()
        {
            CurHealth = maxHealth;
        }
    }

    public EnemyStats stats = new EnemyStats();
    
    // Use this for initialization
    private void Start ()
    {
        stats.Init();
    }

    public void DamageEnemy(int damage)
    {
        Debug.Log("Enemy got hit for " + damage + " damage");
        stats.CurHealth -= damage;
        if (stats.CurHealth <= 0)
        {
            GameMaster.KillEnemy(this);
        }
    }

}
