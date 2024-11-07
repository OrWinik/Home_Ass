using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class AnimationUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI text1, text2, text3;
    [SerializeField] private TMP_InputField input1, input2, input3;
    [SerializeField] private Button submitButton;
    [SerializeField] private Transform shelf;

    void Start()
    {
        AnimateUIEntrance();
    }

    private void AnimateUIEntrance()
    {
        //Header pop in
        headerText.transform.localPosition += new Vector3(0, 300, 0);

        headerText.transform.DOLocalMoveY(headerText.transform.localPosition.y - 300, 1.0f).SetEase(Ease.OutExpo).SetDelay(0.6f);

        // Text pop in
        text1.transform.localPosition += new Vector3(0, 300, 0);
        text2.transform.localPosition += new Vector3(0, 300, 0);
        text3.transform.localPosition += new Vector3(0, 300, 0);

        text1.transform.DOLocalMoveY(text1.transform.localPosition.y - 300, 1.0f).SetEase(Ease.OutExpo).SetDelay(0.6f);
        text2.transform.DOLocalMoveY(text2.transform.localPosition.y - 300, 1.0f).SetEase(Ease.OutExpo).SetDelay(0.8f);
        text3.transform.DOLocalMoveY(text3.transform.localPosition.y - 300, 1.0f).SetEase(Ease.OutExpo).SetDelay(1.0f);

        // Input fields pop in
        input1.transform.localPosition += new Vector3(0, 300, 0);
        input2.transform.localPosition += new Vector3(0, 300, 0);
        input3.transform.localPosition += new Vector3(0, 300, 0);

        input1.transform.DOLocalMoveY(input1.transform.localPosition.y - 300, 1.0f).SetEase(Ease.OutExpo).SetDelay(0.6f);
        input2.transform.DOLocalMoveY(input2.transform.localPosition.y - 300, 1.0f).SetEase(Ease.OutExpo).SetDelay(0.8f);
        input3.transform.DOLocalMoveY(input3.transform.localPosition.y - 300, 1.0f).SetEase(Ease.OutExpo).SetDelay(1.0f);

        // Submit button 
        submitButton.transform.localScale = Vector3.zero;
        submitButton.image.DOFade(1, 1.0f).SetDelay(1.4f);
        submitButton.transform.DOScale(1.2f, 1.2f).SetEase(Ease.OutBack).SetDelay(1.4f);

        Invoke("ExpandingShelf", 2f);

    }

    public void ExpandingShelf()
    {
        // Ensure shelf starts from scale 0 (no size)
        shelf.localScale = Vector3.zero;

        // Expand to full size over 1.5 seconds with a smooth back-out effect
        shelf.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutBack);
    }
}
