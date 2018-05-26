using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {

  public int MaxHP;
  private int currentHP;

  public int MaxSP;
  private int currentSP;

  private GameObject Ability;

  private bool alive = true;


	public void Start () {
    currentHP = MaxHP;
    currentSP = MaxSP;
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
