using UnityEngine;

public class Highlighter : MonoBehaviour
{
    Renderer _meshRenderer;
    Color _originalColor;

    void Start()
    {
        _meshRenderer = GetComponent<Renderer>();
        _originalColor = _meshRenderer.material.color;
    }

    public void Highlight(bool active)
    {
        if (active)
        {
            _meshRenderer.material.color = Color.yellow;
        }
        else
        {
            _meshRenderer.material.color = _originalColor;

        }
    }
}
