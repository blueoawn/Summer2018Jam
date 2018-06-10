using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private GameObject target = null;
    private Vector3 direction;
    private float speed = 1.0f;
    private bool fired = false;
    private int damage;

    public void Fire(GameObject target, int damage) {
        this.target = target;
        this.damage = damage;
        direction = target.transform.position - transform.position;
        fired = true;
    }

    public void Update() {
        if (fired) {
            transform.Translate(Time.deltaTime * speed * direction); 
        }
    }

    public void OnTriggerEnter(Collider other) {
        Combat otherCombat = other.gameObject.GetComponent<Combat>();
        if (otherCombat != null) {
            otherCombat.TakeDamage(damage);
            Destroy(gameObject);
        }
    }


}





