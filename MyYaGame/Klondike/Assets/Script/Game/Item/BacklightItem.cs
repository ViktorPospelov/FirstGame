using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class BacklightItem : MonoBehaviour
{
    [SerializeField]private Image _sprite;
    [SerializeField] private GameObject _img;

    private Coroutine _coroutine;
    private void Start()
    {
        Color color = _sprite.color;
        color.a = 0f;
        _sprite.color = color;
    }

    public void Blink()
    {
        _img.SetActive(true);
        _coroutine = StartCoroutine(Backlight());
    }

    private IEnumerator Backlight()
    {
        /*for (float f = 0.05f; f <= 0.05f; f+=0.05f)
        {
            Color color = _sprite.color;
            color.a = f;
            _sprite.color = color;
            yield return new WaitForSeconds(0.02f);
        }
        for (float f = 0.7f; f >= 0.06f; f-=0.05f)
        {
            Color color = _sprite.color;
            color.a = f;
            _sprite.color = color;
            yield return new WaitForSeconds(0.04f);
        }
        Color colorEnd = _sprite.color;
        colorEnd.a = 0f;
        _sprite.color = colorEnd;
        _img.SetActive(false);
        StopCoroutine(_coroutine);*/
    }
}
