using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour {

    #region TWEENING
    [Header("Tweening options - BaseView")]
    [BoxGroup("Movement")] [SerializeField] protected Vector3 hiddenPosition;
    [BoxGroup("Movement")] [SerializeField] protected Vector3 shownPosition;

    [BoxGroup("Scaling")] [SerializeField] [ReadOnly] protected float defaultAnimationSizeScale = 1.1f;

    [Header("Custom tweening options - BaseView")]
    [BoxGroup("Scaling")] [SerializeField] protected bool useCustonAnimationSizeScale;
    [BoxGroup("Scaling")] [SerializeField] [EnableIf("useCustonAnimationSizeScale")] protected float customAnimationSizeScale;

    protected Sequence sequence;

    public virtual void ScaleUp()
    {
        float scaleSize = useCustonAnimationSizeScale ? customAnimationSizeScale : defaultAnimationSizeScale;
        sequence.Kill();
        sequence = DOTween.Sequence().Append(transform.DOScale(new Vector3(scaleSize, scaleSize, 1), .5f)).Play();
    }

    public virtual void ScaleDown()
    {
        sequence.Kill();
        sequence = DOTween.Sequence().Append(transform.DOScale(new Vector3(1, 1, 1), .3f)).Play();
    }

    public virtual void DefaultPosition()
    {
        //sequence.Kill();
        sequence = DOTween.Sequence().Append(transform.DOLocalMove(hiddenPosition, .3f)).Play();
        gameObject.SetActive(false);
    }

    public virtual void ShowPosition()
    {
        //sequence.Kill();
        sequence = DOTween.Sequence().Append(this.transform.DOLocalMove(hiddenPosition, 0f)).Append(this.transform.DOLocalMove(shownPosition, .3f)).Play();
        gameObject.SetActive(true);
    }

    public virtual void ShowAndHide()
    {
        gameObject.SetActive(true);
        sequence = DOTween.Sequence().Append(this.transform.DOLocalMove(hiddenPosition, 0f)).Append(this.transform.DOLocalMove(shownPosition, .5f)).Play();
        sequence = DOTween.Sequence().SetDelay(2f).Append(this.transform.DOLocalMove(hiddenPosition, .5f)).Play();
        //gameObject.SetActive(false);
    }
    public virtual void ScaleUpAndShow()
    {
        gameObject.SetActive(true);
        sequence = DOTween.Sequence().
            Append(this.transform.DOScale(new Vector3(0, 0, 0), 0f)).
            Append(this.transform.DOScale(new Vector3(1, 1, 1), .5f)).
            Append(this.transform.DOScale(new Vector3(1, 1, 1), 2f)).
            Append(this.transform.DOScale(new Vector3(0, 0, 0), .5f)).Play();
    }
    #endregion

    public virtual void ShowView()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideView()
    {
        this.gameObject.SetActive(false);
    }
}
