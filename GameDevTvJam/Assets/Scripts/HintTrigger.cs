/*
 * Author: Serhii
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class HintTrigger : MonoBehaviour
{
    [TextArea(5, 10)]
    [SerializeField] private string _textToHint;
    [SerializeField] private TMP_Text _hintText;
    [SerializeField] private GameObject _hintPanel;
    [SerializeField] private float _tweenDuration = 1f; // Длительность анимации
    [SerializeField] private Vector2 _startPosition; // начальная позиция панели
    [SerializeField] private Vector2 _endPosition; // конечная позиция панели

    // Start is called before the first frame update
    void Start()
    {
        // Устанавливаем начальное положение панели подсказок
        _hintPanel.GetComponent<RectTransform>().anchoredPosition = _startPosition;
        _hintPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        _hintText.text = _textToHint;
        if (other.gameObject.CompareTag("Player"))
        {
            _hintPanel.SetActive(true);
            // Плавно поднимаем _hintPanel вверх с помощью DOTween
            _hintPanel.GetComponent<RectTransform>().DOAnchorPos(_endPosition, _tweenDuration);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Возвращаем панель подсказки в исходное положение, когда игрок покидает зону триггера
            _hintPanel.GetComponent<RectTransform>().DOAnchorPos(_startPosition, _tweenDuration).OnComplete(() => _hintPanel.SetActive(false));
            Destroy(gameObject, 1f);
        }
    }
}
