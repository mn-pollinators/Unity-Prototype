namespace GoogleARCore.Examples.AugmentedImage
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GoogleARCore;

    public class FlowerVisualizer : MonoBehaviour
    {
        public AugmentedImage Image;

        public GameObject[] flowerSprites;

        public RoundHandler roundHandler;

        private int currentSprite;

        // Called before the first Update
        void Start()
        {
            currentSprite = 0;
            
            foreach (GameObject sprite in flowerSprites)
            {
                sprite.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Hide the flower if the image is no longer being tracked
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                flowerSprites[currentSprite].SetActive(false);
                return;
            }

            flowerSprites[currentSprite].SetActive(false);
            // maps image to sprite based on database index
            currentSprite = roundHandler.ConvertImageToSprite(Image.DatabaseIndex);
            // sprite faces the camera at all times
            flowerSprites[currentSprite].transform.LookAt(Camera.main.transform.position, Vector3.up);
            flowerSprites[currentSprite].SetActive(true);
        }
    }
}
