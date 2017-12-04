using UnityEngine;

public class TearShot : MonoBehaviour {

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player player = collision.collider.GetComponent<Player>();
        Debug.Log("Tear hit " + collision.collider.name + "!");
        Destroy(this.gameObject);
    }
    */

    [SerializeField]
    private int m_damage = 10;
    public int Damage
    {
        get { return m_damage;  }
        set { m_damage = value;  }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Tear hit " + collision.gameObject.name + "!");
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.DamageEnemy(m_damage);
        }
        Destroy(this.gameObject);
    }
}
