using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
  private GameObject target = null;
  private Vector3 direction;

  public void SetTarget(GameObject target) {
      this.target = target; 
      direction = target.transform.position - transform.position;
  }

  public void Update() {
      if (target != null) {
          transform.Translate(direction); 
      }
  }


}



  

