using UnityEngine;

public class Gem : MonoBehaviour
{
    public string gemColorName = string.Empty;
    BoxManager boxManager;
    Material material;
    private Color originalEmissionColor;

    private void Start()
    {
        boxManager = FindObjectOfType<BoxManager>();
        if (boxManager == null )
        {
            Debug.LogError("Box Manager on Gem is Null");
        }
        material = GetComponent<MeshRenderer>().material;
        if (material == null )
        {
            Debug.LogError("Material on Gem is null");
        }
        originalEmissionColor = material.GetColor("_EmissionColor");
        material.SetColor("_EmissionColor", Color.black);
    }

    public void SelectedGem()
    {
        ChangeEmission(true);
        boxManager.GemSelect(this);
    }

    public void ChangeEmission(bool isEmitting)
    {
        if (isEmitting)
        {
            material.SetColor("_EmissionColor", originalEmissionColor);
        }
        else
        {
            material.SetColor("_EmissionColor", Color.black);
        }
    }
}
