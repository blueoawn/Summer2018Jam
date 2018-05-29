//the UnitWorldUI game object is attached to each combat unit. it provides a target indicator and a health bar.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnitWorldUI : MonoBehaviour {

    public GameObject targetIndicator;
    public GameObject healthBar;

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "PathfindingTesting")
            SetHealthBarVisibility(false);
        else
            SetHealthBarVisibility(true);
    }

    public void SetTargetIndicatorVisibility(bool visibility) {
        targetIndicator.SetActive(visibility);
    }

    public void SetHealthBarVisibility(bool vis) {
        healthBar.SetActive(vis);
    }

    public void SetHealthBarValue(float val) {
        healthBar.GetComponent<Slider>().value = val;
    }
}
