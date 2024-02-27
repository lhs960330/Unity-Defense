using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    [SerializeField] Vector3 targetPos;
    [SerializeField] int damage;
    [SerializeField] float time;
    [SerializeField] float range;
    [SerializeField] LayerMask mask;

    public void SetTargetPos(Vector3 targetPos)
    {
        this.targetPos = targetPos;
        StartCoroutine(CanonRoutine(transform.position, targetPos));
    }
    IEnumerator CanonRoutine(Vector3 startPos, Vector3 targetPos)
    {
        float ySpeed = -1 * (0.5f * Physics.gravity.y * time * time + startPos.y) / time;
        float rate = 0f;
        while (rate < 1f)
        {
            rate += Time.deltaTime / time;
            if (rate > 1f)
            {
                rate = 1f;
            }
            Vector3 vec3 = Vector3.Lerp(startPos, targetPos, rate);
            transform.position = new Vector3(vec3.x, transform.position.y, vec3.z);

            ySpeed += Physics.gravity.y * Time.deltaTime;
            transform.Translate(Vector3.up * ySpeed * Time.deltaTime);

            yield return null;
        }

        Explosion();
    }
    private void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, mask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Monster monster = colliders[i].gameObject.GetComponent<Monster>();
            monster.TakeDamage(damage);

        }
        Destroy(gameObject);
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
