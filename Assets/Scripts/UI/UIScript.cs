using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;

public class UIScript : MonoBehaviour
{
    // R�f�rence au composant TMP_Text
    public TMP_Text tmpText;
    [SerializeField] private SoundManager soundManager;

    // R�f�rence au composant VideoPlayer
    public VideoPlayer videoPlayer;

    // Liste de messages � afficher dans TMP
    public List<string> messages = new List<string>
    {
        "1. Epluchez, épépinez et coupez les pommes en dés.",
        "2. Placez-en les 3/4 dans une casserole, et garder le reste de côté.",
        "3. Ajoutez le sucre en poudre, la cannelle, et l'eau.",
        "4. Faites cuire à feu doux pendant environ 20 min et remuez régulièrement (lancer plein de sous chrono pour dire de remuez)",
        "5. Préparez la pâte à crumble. Versez la farine et le sucre en poudre dans un saladier",
        "6. Ajoutez le beurre coupé en dés.",
        "7. Pétrissez la pâte du bout des doigts jusqu'à obtention d'une pâte granuleuse.",
        "8. Attendre la fin du chrono (à ignorer si chrono déjà fini).",
        "9. Versez la compote dans un plat à gratin.",
        "10. Répartissez la pâte à crumble sur la compote de pommes, ainsi que les morceaux de pommes mis de côté.",
        "11. Vous avez terminé la démonstration !"
    };

    // Liste de clips vid�o associ�s � chaque message
    public List<VideoClip> videoClips = new List<VideoClip>();

    // Variable de progression modifiable pour changer le texte et la vid�o
    public int currentIndex = 0; // Cet index peut �tre modifi� manuellement ou par un autre script

    void Start()
    {
        // V�rifie si tmpText est assign�, sinon essaie de le r�cup�rer
        if (tmpText == null)
        {
            tmpText = GetComponent<TMP_Text>();
        }

        // V�rifie si videoPlayer est assign�, sinon essaie de le r�cup�rer
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Affiche le premier message et la premi�re vid�o
        UpdateTextAndVideo();
    }

    // M�thode pour mettre � jour le texte et la vid�o en fonction de currentIndex
    public void UpdateTextAndVideo()
    {
        // V�rifie si l'index est valide
        if (currentIndex >= 0 && currentIndex < messages.Count)
        {
            // Mise � jour du texte
            tmpText.text = messages[currentIndex];

            // Mise � jour de la vid�o (si disponible)
            if (currentIndex < videoClips.Count)
            {
                videoPlayer.clip = videoClips[currentIndex];
                videoPlayer.Play();  // Joue la vid�o correspondante
            }
        }
    }

    // Exemple de m�thode pour modifier la variable `currentIndex` depuis un autre script ou �v�nement
    public void ChangeProgress()
    {
        if (currentIndex + 1 < messages.Count)
        {
            currentIndex++;  // Modifie l'index
            UpdateTextAndVideo();  // Met � jour le texte et la vid�o
            soundManager.PlayNextSound();


        }
    }

    public void StopRecipe() {
        currentIndex = messages.Count;  // Modifie l'index
        UpdateTextAndVideo();  // Met � jour le texte et la vid�o
    }
}
