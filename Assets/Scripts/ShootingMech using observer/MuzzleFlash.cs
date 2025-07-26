using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    private SpriteRenderer sr;
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Called via animation event
    public void ShowFlash()
    {
        sr.enabled = true;
    }

    public void HideFlash()
    {
        sr.enabled = false;
    }
}
