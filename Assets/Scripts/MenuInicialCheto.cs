using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicialCheto : MonoBehaviour
{
    [Header("Opciones")]
    public Slider MasterVol;
    public Slider FXVol;
    public AudioMixer mixer;
    public AudioSource FXSource;
    public AudioClip clicksound;

    [Header("Paneles")]
    public GameObject panelcheto;
    public GameObject opciones;
    public GameObject seleccionarjug;

    private void Awake(){
        FXVol.onValueChanged.AddListener(CambiarVolFX);
        MasterVol.onValueChanged.AddListener(CambiarVolMaster);
    }

    public void OpenPanel(GameObject panel){
        panelcheto.SetActive(false);
        opciones.SetActive(false);
        seleccionarjug.SetActive(false);

        panel.SetActive(true);
        PlaySoundButtom();

    }

    public void CambiarVolMaster(float v){
        mixer.SetFloat("MasterVol", v);
    }
    
    public void CambiarVolFX(float v){
        mixer.SetFloat("VolFX", v);
    }

    public void PlaySoundButtom(){
        FXSource.PlayOneShot(clicksound);
    }

    public void Jugar(string levelName){
        SceneManager.LoadScene(levelName);
    }

    public void Exit(){
        Debug.Log("Saliste Del Juego");
        Application.Quit();
    }
}
