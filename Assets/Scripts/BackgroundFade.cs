using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundFade : MonoBehaviour
{
    public List<SpriteRenderer> backgrounds;  
    public float fadeDuration = 2f;  
    private int currentBackgroundIndex = 0; 
    public static BackgroundFade instance;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        for (int i = 0; i < backgrounds.Count; i++)
        {
            if (i == currentBackgroundIndex)
                backgrounds[i].color = new Color(1, 1, 1, 1); 
            else
                backgrounds[i].color = new Color(1, 1, 1, 0); 
        }
    }

    public void StartBackgroundTransition()
    {
        StartCoroutine(FadeToNextBackground());
    }

    private IEnumerator FadeToNextBackground()
    {
        int nextBackgroundIndex = (currentBackgroundIndex + 1) % backgrounds.Count;  // S�radaki arka plan� belirle

        SpriteRenderer currentBackground = backgrounds[currentBackgroundIndex];
        SpriteRenderer nextBackground = backgrounds[nextBackgroundIndex];

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = timer / fadeDuration;

            // Mevcut arka plan� yava� yava� �effaf yap�yoruz
            currentBackground.color = new Color(1, 1, 1, 1 - alpha);

            // S�radaki arka plan� yava� yava� g�r�n�r yap�yoruz
            nextBackground.color = new Color(1, 1, 1, alpha);

            yield return null;
        }

        // Ge�i� tamamland���nda, s�ralamay� g�ncelle
        currentBackgroundIndex = nextBackgroundIndex;
    }
}
