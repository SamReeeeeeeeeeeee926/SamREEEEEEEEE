using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{

    public dullstar status;

  

   public void Update()
    {
       if(status.gotIt == true)
        {
            Debug.Log("You can go in the door now!");
        }else
        {
            Debug.LogWarning("Not Yet/The DullStar is not stup yet.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(status.gotIt == true)
        {
            Debug.Log("It Worked!");
            SceneManager.LoadScene("Win");
        } else if(status == null)
        {
            Debug.LogWarning("The Object is not attached to your door. It might have unassigned it while pressing play.");
        }
    }
}
