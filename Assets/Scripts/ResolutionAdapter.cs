using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ResolutionAdapter : MonoBehaviour
{
    private Image targetImage;
    private RectTransform imageRect;
    private RectTransform prevImageRect;
    private Vector2 screenSize;

    private BoxCollider boxCollider;
    private BoxCollider2D boxCollider2D;
    private float ratio;

    private void Awake()
    {
        screenSize = new Vector2(1170, 2532); //Default screen size (iphone12)

        imageRect = GetComponent<RectTransform>();
        boxCollider = GetComponent<BoxCollider>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        if (screenSize.x != Screen.width || screenSize.y != Screen.height)
        {
            ResizeRectTransform();
            if (boxCollider != null) ResizeBoxCollider();
            if (boxCollider2D != null) ResizeBoxCollider2D();
        }
    }

    private void ResizeRectTransform()
    {
        Vector2 imagePos = imageRect.anchoredPosition;
        Vector3 prevScale = imageRect.localScale;

        float imageWPercent = imageRect.rect.width / screenSize.x;
        float imageHPercent = imageRect.rect.height / screenSize.y;

        float rap = prevScale.x / prevScale.y;

        float percentX = imagePos.x / screenSize.x;
        float percentY = imagePos.y / screenSize.y;

        float posX = Screen.width * percentX;
        float posY = Screen.height * percentY;

        float newScaleX = prevScale.x * Screen.width / screenSize.x;
        float newScaleY = prevScale.y * Screen.height / screenSize.y;

        float min = Mathf.Min(newScaleX, newScaleY);
        if (min == newScaleX) {
            newScaleY = (1 / rap) * newScaleX;
        } else {
            newScaleX = rap * newScaleY;
        }

        imageRect.anchoredPosition = new Vector2(posX, posY);
        prevImageRect = imageRect;
        imageRect.localScale = new Vector3(newScaleX, newScaleY, prevScale.z);
    }

    private void ResizeBoxCollider()
    {
        float colliderW = boxCollider.size.x;
        float colliderH = boxCollider.size.y;

        float rap = colliderW / colliderH;

        float colliderWPercent = colliderW / prevImageRect.rect.width;
        float colliderHPercent = colliderH / prevImageRect.rect.height;

        float newWidth = imageRect.rect.width * colliderWPercent;
        float newHeight = imageRect.rect.height * colliderHPercent;

        float min = Mathf.Min(newWidth, newHeight);

        if (min == newWidth) {
            newHeight = (1 / rap) * newWidth;
        } else {
            newWidth = rap * newHeight;
        }

        boxCollider.size = new Vector3(newWidth, newHeight, boxCollider.size.z);
    }

    private void ResizeBoxCollider2D()
    {
        float colliderW = boxCollider2D.size.x;
        float colliderH = boxCollider2D.size.y;

        float rap = colliderW / colliderH;

        float colliderWPercent = colliderW / prevImageRect.rect.width;
        float colliderHPercent = colliderH / prevImageRect.rect.height;

        float newWidth = imageRect.rect.width * colliderWPercent;
        float newHeight = imageRect.rect.height * colliderHPercent;

        float min = Mathf.Min(newWidth, newHeight);

        if (min == newWidth) {
            newHeight = (1 / rap) * newWidth;
        } else {
            newWidth = rap * newHeight;
        }

        boxCollider2D.size = new Vector2(newWidth, newHeight);
    }

}