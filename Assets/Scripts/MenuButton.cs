using UnityEngine;
using UnityEngine.Events;
public class MenuButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();

    public Color HoverColor;

    void Start()
    {
        definedButton = this.gameObject;
    }

    private void OnMouseDown()
    {
        OnClick.Invoke();
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = HoverColor;
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
