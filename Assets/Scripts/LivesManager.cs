using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public int lives = 3; // Set this to the maximum number of images you want to have

    public int leaves = 0;

    public float score = 0;
    public int leavesToLife = 5;
    public GameObject imagePrefab; // Set this to the prefab you want to use for the images
    private List<GameObject> imageList = new List<GameObject>(); 

    private Vector2 position = new Vector2(-80f, 0f);

    public TextMeshProUGUI info;

    private void FixedUpdate()
    {
        // Check if the number of images in the list is greater than the maxImages
        while (imageList.Count > lives)
        {
            GameObject image = imageList[imageList.Count - 1];
            imageList.RemoveAt(imageList.Count - 1);
            position = position - new Vector2(80f, 0f);
            Destroy(image);
        }
        while (imageList.Count < lives){
            // Instantiate the new object at the calculated position
            GameObject image = Instantiate(imagePrefab);

            image.transform.SetParent(transform);
            RectTransform rectTransform = image.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = position;

            // Add the new object to the list and update the last object position
            imageList.Add(image);
            position = position + new Vector2(80f, 0f);
        }
        if(leaves >= leavesToLife){
            lives += 1;
            leaves -= leavesToLife;
        }
        if(lives > 0){
            score += 0.1f;
        }

        info.text = "Score: " + Mathf.RoundToInt(score) + "\nLeaves: " + leaves;
    }
}
