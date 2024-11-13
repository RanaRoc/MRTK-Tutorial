using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Référence au composant TMP_Text
    public TMP_Text tmpText;

    // Référence au composant VideoPlayer
    public VideoPlayer videoPlayer;

    // Liste de messages à afficher dans TMP
    private List<string> messages = new List<string>
    {
        "1. Épluchez, épépinez et coupez les pommes en dés.",
        "2. Placez-en les 3/4 dans une casserole, et garder le reste de coté.",
        "3. Ajoutez le sucre en poudre, la cannelle, et l'eau.",
        "4. Faites cuire à feu doux pendant environ 20 min et remuez régulièrement (lancer plein de sous chrono pour dire de remuez)",
        "5. Préparez la pâte à crumble. Versez la farine et le sucre en poudre dans un saladier",
        "6. Ajoutez le beurre coupé en dés.",
        "7. Pétrissez la pâte du bout des doigts jusqu'à obtention d'une pâte granuleuse.",
        "8. Répartissez la pâte à crumble sur la compote de pommes.",
        "9. Attendre la fin du chrono (à ignorer si chrono déjà fini).",
        "10. Versez la compote dans un plat à gratin.",
        "11. Répartissez la pâte à crumble sur la compote de pommes, ainsi que les morceaux de pommes mis de côté."
    };

    // Liste de clips vidéo associés à chaque message
    public List<VideoClip> videoClips = new List<VideoClip>();

    // Variable de progression modifiable pour changer le texte et la vidéo
    public int currentIndex = 0; // Cet index peut être modifié manuellement ou par un autre script

    void Start()
    {
        // Vérifie si tmpText est assigné, sinon essaie de le récupérer
        if (tmpText == null)
        {
            tmpText = GetComponent<TMP_Text>();
        }

        // Vérifie si videoPlayer est assigné, sinon essaie de le récupérer
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Affiche le premier message et la première vidéo
        UpdateTextAndVideo();
    }

    // Méthode pour mettre à jour le texte et la vidéo en fonction de currentIndex
    public void UpdateTextAndVideo()
    {
        // Vérifie si l'index est valide
        if (currentIndex >= 0 && currentIndex < messages.Count)
        {
            // Mise à jour du texte
            tmpText.text = messages[currentIndex];

            // Mise à jour de la vidéo (si disponible)
            if (currentIndex < videoClips.Count)
            {
                videoPlayer.clip = videoClips[currentIndex];
                videoPlayer.Play();  // Joue la vidéo correspondante
            }
        }
    }

    // Exemple de méthode pour modifier la variable `currentIndex` depuis un autre script ou événement
    public void ChangeProgress(int newIndex)
    {
        if (newIndex >= 0 && newIndex < messages.Count)
        {
            currentIndex = newIndex;  // Modifie l'index
            UpdateTextAndVideo();  // Met à jour le texte et la vidéo
        }
    }
}
