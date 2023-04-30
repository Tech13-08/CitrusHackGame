using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LivesManager : MonoBehaviour
{
    // Create a list to hold the child game objects
    public List<Image> childObjects = new List<Image>();

    public int lives = 3;

    public void Remove(){
        // Check if the list has more than 0 elements
        if (childObjects.Count > 0)
        {
            // Get the last child object in the list
            Image lastChild = childObjects[childObjects.Count - 1];
            
            // Remove the last child object from the list
            childObjects.Remove(lastChild);
            
            // Destroy the last child object
            Destroy(lastChild.gameObject);
            lives -= 1;
        }
    }


        // Add a new image to the list and return it
        // public Image AddLife(Sprite sprite)
        // {
        //     // Instantiate a new game object and add an Image component to it
        //     GameObject newImageObject = new GameObject("Image");
        //     Image newImage = newImageObject.AddComponent<Image>();

        //     // Set the sprite of the new Image component
        //     newImage.sprite = sprite;

        //     // Set the parent of the new Image component to this object
        //     newImage.transform.SetParent(transform, false);

        //     // Add the new Image component to the list
        //     images.Add(newImage);

        //     // Return the new Image component
        //     return newImage;
        // }

}
