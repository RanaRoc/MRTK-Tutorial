using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // R�f�rence au composant TMP_Text
    public TMP_Text tmpText;
    [SerializeField] private SoundManager soundManager;

    // R�f�rence au composant VideoPlayer
    public VideoPlayer videoPlayer;

    // Liste de messages � afficher dans TMP
    private List<string> messages = new List<string>
    {
        "1. �pluchez, �p�pinez et coupez les pommes en d�s.",
        "2. Placez-en les 3/4 dans une casserole, et garder le reste de cot�.",
        "3. Ajoutez le sucre en poudre, la cannelle, et l'eau.",
        "4. Faites cuire � feu doux pendant environ 20 min et remuez r�guli�rement (lancer plein de sous chrono pour dire de remuez)",
        "5. Pr�parez la p�te � crumble. Versez la farine et le sucre en poudre dans un saladier",
        "6. Ajoutez le beurre coup� en d�s.",
        "7. P�trissez la p�te du bout des doigts jusqu'� obtention d'une p�te granuleuse.",
        "8. R�partissez la p�te � crumble sur la compote de pommes.",
        "9. Attendre la fin du chrono (� ignorer si chrono d�j� fini).",
        "10. Versez la compote dans un plat � gratin.",
        "11. R�partissez la p�te � crumble sur la compote de pommes, ainsi que les morceaux de pommes mis de c�t�."
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
                soundManager.PlayNextSound();

            }
        }
    }

    // Exemple de m�thode pour modifier la variable `currentIndex` depuis un autre script ou �v�nement
    public void ChangeProgress(int newIndex)
    {
        if (newIndex >= 0 && newIndex < messages.Count)
        {
            currentIndex = newIndex;  // Modifie l'index
            UpdateTextAndVideo();  // Met � jour le texte et la vid�o
        }
    }
}
