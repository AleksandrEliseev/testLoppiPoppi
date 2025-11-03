using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExpressionResultView.View
{
    public class ResultView : MonoBehaviour, IResultView
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private RectTransform _generalContent;
        [SerializeField] private RectTransform _content;
        [SerializeField] private ResultItemScrollView _resultItemPrefab;
        [SerializeField] private float _maxContentHeight = 500f;

        private List<ResultItemScrollView> _resultItems = new();

        public void AddResult(string result)
        {
            ResultItemScrollView resultItem = Instantiate(_resultItemPrefab, _content);
            resultItem.SetResultText(result);
            _resultItems.Add(resultItem);
        }
        
        public void UpdateScrollSize()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
            float currentHeight = _content.sizeDelta.y;
            _scrollRect.vertical = currentHeight > _maxContentHeight;
            _generalContent.sizeDelta = new Vector2(_generalContent.sizeDelta.x,
                Mathf.Min(currentHeight, _maxContentHeight));
            LayoutRebuilder.ForceRebuildLayoutImmediate(_generalContent);
        }
    }
}