using TMPro;
using UnityEngine;

namespace ExpressionResultView.View
{
    public class ResultItemScrollView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _resultText;
        
        public void SetResultText(string text)
        {
            _resultText.text = text;
        }
    }
}