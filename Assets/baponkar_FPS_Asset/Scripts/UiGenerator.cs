using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Baponkar.FPS
    {
    public class UiGenerator : MonoBehaviour
    {
        public GameObject uiPrefab;
        Slider healthSlider;
        Text weaponText;
        // Start is called before the first frame update
        void Start()
        {
            var prefab = Instantiate(uiPrefab, transform);
            prefab.transform.SetParent(transform,false);
            healthSlider = prefab.GetComponentInChildren<Slider>();
            weaponText = prefab.GetComponentInChildren<Text>();

            GetComponent<Health>().healthSlider = healthSlider;
            GetComponent<CharacterFightControl>().text = weaponText;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}