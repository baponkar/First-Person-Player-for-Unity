using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Baponkar.FPS
    {
    public class UiGenerator : MonoBehaviour
    {
        public GameObject uiPrefab;
        public GameObject mobileCanvas;
        Slider healthSlider;
        Text weaponText;

        PlayerControlInput playerControlInput;
        bool mobileCanvasActivated;

        // Start is called before the first frame update
        void Start()
        {
            var prefab = Instantiate(uiPrefab, transform);
            prefab.transform.SetParent(transform,false);
            healthSlider = prefab.GetComponentInChildren<Slider>();
            weaponText = prefab.GetComponentsInChildren<Text>()[1];

            GetComponent<Health>().healthSlider = healthSlider;
            GetComponent<CharacterFightControl>().text = weaponText;
            playerControlInput = GetComponent<PlayerControlInput>();

            if(playerControlInput.mobileInput)
            {
                var mobilePrefab = Instantiate(mobileCanvas, transform);
                mobilePrefab.transform.SetParent(prefab.transform, false);
            }
        }

        // Update is called once per frame
        void Update()
        {
    
        }
    }
}