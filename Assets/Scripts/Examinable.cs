using UnityEngine;

public class Examinable : MonoBehaviour
{
    private ExaminableManager _examinableManager;
    public float scaleOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _examinableManager = FindObjectOfType<ExaminableManager>();    
        if (_examinableManager == null)
        {
            Debug.LogError("Examinable Manager not found on " + name);
        }
    }

    public void RequestExamine()
    {
        _examinableManager.PerformExamine(this);
    }

    public void RequestUnexamine()
    {
        _examinableManager.PerformUnexamine();
    }
}
