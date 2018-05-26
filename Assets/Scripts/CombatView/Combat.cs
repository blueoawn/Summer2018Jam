using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {

  public int maxHP;
  private int currentHP;

  public int maxSP;
  private int currentSP;

  private GameObject ability;

  private bool alive = true;


  public void Start () {
      currentHP = maxHP;
      currentSP = maxSP;
  }

  public void TakeDamage(int amount) {
    this.currentHP -= amount;
    if (this.currentHP <= 0) {
      die();
    }
  }

  private void die() {
    this.alive = false;
  }
	
  
}
