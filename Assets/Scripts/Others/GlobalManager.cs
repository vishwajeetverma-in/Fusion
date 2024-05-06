using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance { get; private set; }
    [field: SerializeField] public NetworkRunnerController networkRunnerController { get; private set; }
    [SerializeField] private GameObject parentObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(parentObject);
        }
    }


}
