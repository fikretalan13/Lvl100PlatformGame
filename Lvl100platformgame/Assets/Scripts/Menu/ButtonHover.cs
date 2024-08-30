using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f); // Butonun büyüyeceği ölçek
    private Vector3 originalScale; // Butonun orijinal ölçeği

    private void Start()
    {
        originalScale = transform.localScale; // Orijinal ölçeği sakla
    }

    // Mouse butonun üzerine geldiğinde çalışır
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = hoverScale; // Butonun ölçeğini değiştir
    }

    // Mouse butondan çıktığında çalışır
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale; // Butonu eski boyutuna döndür
    }
}
