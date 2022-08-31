using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour, IInitable
{
    public virtual void Init()
    {
        Subscribe();
    }

    protected virtual void OnDestroy()
    {
        Unsubscribe();
    }

    protected virtual void Subscribe()
    {
        Events.OnGameReset += GameReset;
    }

    protected virtual void Unsubscribe()
    {
        Events.OnGameReset -= GameReset;
    }

    protected virtual void GameReset()
    {
    }

    protected void Enable()
    {
        this.gameObject.SetActive(true);
    }

    protected void Disable()
    {
        this.gameObject.SetActive(false);
    }

    protected void SetImageAlpa(Image image, int alpha)
    {
        var tempColor = image.color;
        tempColor.a = alpha;
        image.color = tempColor;
    }

    protected void ChangeRaycastableTarget(Image image, bool raycastable)
    {
        image.raycastTarget = raycastable;
    }

    protected void ChangeRaycastableTarget(Image image, int raycastable)
    {
        image.raycastTarget = System.Convert.ToBoolean(raycastable);
    }
}
