using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [System.Serializable]
    public class PlayerStats
    {
        private int maxHealth = 100;
        [SerializeField]
        private int curHealth;
        public int CurHealth
        {
            get { return curHealth; }
            set { curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        [SerializeField]
        private int damageModifier;
        public int DamageModifier
        {
            get { return damageModifier; }
            set { damageModifier = value; }
        }

        public void Init()
        {
            CurHealth = maxHealth;
            DamageModifier = 0;
        }
    }

    public PlayerStats stats = new PlayerStats();

    [SerializeField]
    private Transform m_tearShotPrefab;
    [SerializeField]
    private float m_shotSpeed = 50;
    [SerializeField]
    private float m_shotOffsetFromPlayer = 0.5f;

    // Use this for initialization
    private void Start()
    {
        stats.Init();
        if (m_tearShotPrefab == null)
        {
            Debug.LogError("Player has no tear shot prefab!!");
        }
    }

    public void DamagePlayer(int damage)
    {
        stats.CurHealth -= damage;
        if (stats.CurHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

    private void Shoot()
    {
        Debug.Log("SHOOT!");
        Vector2 abovePlayer = new Vector2(transform.position.x, transform.position.y + m_shotOffsetFromPlayer);
        Transform tearShot = Instantiate(m_tearShotPrefab, abovePlayer, transform.rotation) as Transform;
        TearShot tearShotInstance = tearShot.GetComponent<TearShot>();
        tearShotInstance.Damage += stats.DamageModifier;
        Rigidbody2D tearRB = tearShot.GetComponent<Rigidbody2D>();
        tearRB.AddForce(new Vector2(0f, m_shotSpeed));
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
}
