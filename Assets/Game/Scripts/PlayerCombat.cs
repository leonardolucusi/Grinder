using UnityEngine;
public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public int baseAttackDamage = 40;
    public GameObject weapon;
    public float swordAbilityXp;
    public int xp;
    public GameObject enemyPoolerGameObject;
    private EnemyPooler enemyPooler;
    [SerializeField] private bool isAttacking = false;
    public float attackSpd;
    void Start()
    {
        enemyPooler = enemyPoolerGameObject.GetComponent<EnemyPooler>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAttacking == false) Attack();
    }
    public void Attack()
    {
        if (isAttacking == false)
        {
            Item weaponItem = weapon.GetComponent<Item>();
            if (weaponItem.named == "woodenSword")
            {
                isAttacking = true;
                weapon.SetActive(true);
                animator.SetTrigger("Attack");
                animator.speed = weaponItem.attackSpeed;
            }
            else if (weaponItem.named == "woodenDagger")
            {
                isAttacking = true;
                weapon.SetActive(true);
                animator.SetTrigger("daggerAttack");
                animator.speed = weaponItem.attackSpeed;
            }
            else
            {
                // player is attacking with bare hands
            }
        }
    }
    public void EndAttack()
    {
        weapon.SetActive(false);
        isAttacking = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemies"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(weapon.GetComponent<Item>().damage);

            if (enemy.currentHealth <= 0)
            {
                xp += enemy.xpReward();
                enemyPooler.ReturnPooledObject(other.gameObject);
            }
        }
        else Debug.Log(other.name);
    }
}
