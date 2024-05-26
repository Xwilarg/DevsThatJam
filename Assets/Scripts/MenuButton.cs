using UnityEngine;
using UnityEngine.Events;
public class MenuButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();

    void Start()
    {
        definedButton = this.gameObject;
    }

    private void OnMouseDown()
    {
        OnClick.Invoke();
    }
}
