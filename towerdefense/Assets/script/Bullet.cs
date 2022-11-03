using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject ImpactEffect;
    // Start is called before the first frame update
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }    
        Vector3 dir=target.position-transform.position;
        float distanceThisFrame=speed*Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }    
        transform.Translate(dir.normalized*distanceThisFrame,Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
       GameObject effectIns=(GameObject) Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
        if(explosionRadius > 0f)
        {
            Explode();
        }
        else {
            Damage(target);
                } 
        //Destroy(target.gameObject);
        Destroy(gameObject);
    }  
    void Explode()
    {
        //OverlapSphere d�ng ?? t?o ra 1 v�ng tr�n n?u ch?m v�o enemy s? t?o ra v�ng n?
        Collider[] colliders=Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag=="enemy")
            {
                Damage(collider.transform);
            }    
        }    
    }  
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        //v? 1 v�ng tr�n r?ng ?? ph�t hi?n v�ng n? 
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position,explosionRadius);
    }
}
