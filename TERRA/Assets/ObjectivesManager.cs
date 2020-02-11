using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    //public Goal[] goals;
    void Awake()
    {
        //goals = GetComponents<Goal>();
    }

    void OnGUI()
    {
        //foreach (var goal in goals)
        {
            //goals.DrawHUD();
        }
    }

    void Update()
    {
        //foreach (var goal in goals)
        {
            // if (goal.IsAchieved())
            {
                // goal.Complete();
                // Destroy(goal);
            }
        }
    }
}


