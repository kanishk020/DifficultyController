using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float dmgValue = 4;
    public GameObject throwableObject;
    public Transform attackCheck;
    private Rigidbody2D m_Rigidbody2D;
    public Animator animator;
    public bool canAttack = true;
    public bool isTimeToCheck = false;

    public GameObject cam;

    // Fire rate variables
    public float throwCooldown = 0.5f; // Time between each throwable object throw
    public float nextThrowTime = 0f;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && canAttack)
        {
            canAttack = false;
            animator.SetBool("IsAttacking", true);
            StartCoroutine(AttackCooldown());
        }

        if (Input.GetKeyDown(KeyCode.V) && Time.time >= nextThrowTime)
        {
            nextThrowTime = Time.time + throwCooldown; // Update next throw time
            ThrowObject();
        }
    }

    void ThrowObject()
    {
        GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f, +0.1f), Quaternion.identity) as GameObject;
        Vector2 direction = new Vector2(transform.localScale.x, 0);
        throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction;
        throwableWeapon.name = "ThrowableWeapon";
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.25f);
        canAttack = true;
    }

    public void DoDashDamage()
    {
        dmgValue = Mathf.Abs(dmgValue);
        Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
        for (int i = 0; i < collidersEnemies.Length; i++)
        {
            if (collidersEnemies[i].gameObject.tag == "Enemy")
            {
                if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
                {
                    dmgValue = -dmgValue;
                }
                collidersEnemies[i].gameObject.SendMessage("ApplyDamage", dmgValue);
                CameraFollow.instance.ShakeCamera();
            }
        }
    }
}
