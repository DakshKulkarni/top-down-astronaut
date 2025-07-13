using UnityEngine;
public class SecondCharManager : MonoBehaviour
{
    private static GameObject secondCharInstance;
    public static void SpawnSecondChar(GameObject prefab, Vector3 spawnPosition)
    {
        if (secondCharInstance == null)
        {
            secondCharInstance = Instantiate(prefab, spawnPosition, Quaternion.identity);
            secondCharInstance.name = "SecondChar";
            DontDestroyOnLoad(secondCharInstance);
        }
    }
}
