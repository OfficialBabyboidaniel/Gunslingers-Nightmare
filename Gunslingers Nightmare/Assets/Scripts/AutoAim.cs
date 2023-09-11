using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
        // Start is called before the first frame update
    public List<GameObject> enemiesInRange;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if (enemiesInRange.Contains(collider.gameObject) == false)
            { //if the gameObject doesn't exist in the list, add it
                enemiesInRange.Add(collider.gameObject);
                Debug.Log(collider.gameObject.name);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            removeFromList(col.gameObject);
        }
    }

    public void removeFromList(GameObject gameObject)
    {
        if (enemiesInRange.Contains(gameObject) == true)
        { //if the gameObject does exist in the list, remove it
            enemiesInRange.Remove(gameObject);
            Debug.Log(gameObject.name + " is removed.");
        }
    }
}
