using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LivesManager : MonoBehaviour
{
    public int lives = 3;
    public List<Image> childObjects = new List<Image>();

    public void Remove(){
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

}


