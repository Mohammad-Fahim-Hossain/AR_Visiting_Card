using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class ARButtonController : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject ContactButton;
    public GameObject InformationObject;
    public GameObject VideoPlayObject;
    public GameObject BGAudio;
    public GameObject BGcontact;

    public GameObject AciveARbuttonText;
    public GameObject DisableARbuttonText; 

    public GameObject infoVRButton;
    public GameObject ConVRButton;
    public GameObject VidVRButton;
    
    public GameObject CloseInfo;
    public GameObject closecon;
    public GameObject closevid;

    public GameObject BioAudio;

    public GameObject NSULogo;

    public Animator ContactAnim;
    public Animator InformationAnim;
    public AudioSource BGAudioSource;

    public bool sound;


   

    // Start is called before the first frame update
    void Start()
    {

        sound = true;

        VirtualButtonBehaviour[] ARButton = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < ARButton.Length; i++) {

            ARButton[i].RegisterEventHandler(this);
            
        }

        ContactButton.SetActive(false);
        InformationObject.SetActive(false);
        VideoPlayObject.SetActive(false);
        BioAudio.SetActive(false);
        BGcontact.SetActive(false);

        DisableARbuttonText.SetActive(false);

        
        closecon.SetActive(false);
        closevid.SetActive(false);
        CloseInfo.SetActive(false);

        AciveARbuttonText.SetActive(true);

    BGAudioSource = BGAudio.GetComponent<AudioSource>();
        ContactAnim = ContactButton.GetComponent<Animator>();
        InformationAnim = InformationObject.GetComponent<Animator>();
    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {

        if (vb.VirtualButtonName == "Introduction")
        {
            InformationObject.SetActive(true);
            InformationAnim.SetTrigger("OPEN INFO");

            

            VideoPlayObject.SetActive(false);

            NSULogo.SetActive(true);

            BGAudioSource.Pause();

            BGcontact.SetActive(false);
            StartCoroutine(DelayBiosoound());

            infoVRButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
            ConVRButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
            VidVRButton.GetComponent<VirtualButtonBehaviour>().enabled = false;

            CloseInfo.SetActive(true);

            DisableARbuttonText.SetActive(true);
            AciveARbuttonText.SetActive(false);

            sound = false;
        }



        if (vb.VirtualButtonName == "Contact")
        {
            ContactButton.SetActive(true);
            ContactAnim.SetTrigger("OPEN");

           

            VideoPlayObject.SetActive(false);

            NSULogo.SetActive(true);

            BGAudioSource.Pause();
            BioAudio.SetActive(false);

            StartCoroutine(Delaycontactsound());


            infoVRButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
            ConVRButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
            VidVRButton.GetComponent<VirtualButtonBehaviour>().enabled = false;

            closecon.SetActive(true);

            DisableARbuttonText.SetActive(true);
            AciveARbuttonText.SetActive(false);

            sound = false;
        }



        if (vb.VirtualButtonName == "Video") {

            VideoPlayObject.SetActive(true);


            NSULogo.SetActive(false);
            BGAudioSource.Pause();
            BioAudio.SetActive(false);
            BGcontact.SetActive(false);


            infoVRButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
            ConVRButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
            VidVRButton.GetComponent<VirtualButtonBehaviour>().enabled = false;

            closevid.SetActive(true);

            DisableARbuttonText.SetActive(true);
            AciveARbuttonText.SetActive(false);

            sound = false;
        }
    }

    public void resetinfo() {

        InformationAnim.SetTrigger("CLOSE INFO");
        StartCoroutine(MakeFalseObject(InformationObject));

        BioAudio.SetActive(false);
        BGAudioSource.Play();


        infoVRButton.GetComponent<VirtualButtonBehaviour>().enabled = true;
        ConVRButton.GetComponent<VirtualButtonBehaviour>().enabled = true;
        VidVRButton.GetComponent<VirtualButtonBehaviour>().enabled = true;

        CloseInfo.SetActive(false);

        AciveARbuttonText.SetActive(true);
        DisableARbuttonText.SetActive(false);

        sound = true;

    }

    public void resetcontact()
    {

        ContactAnim.SetTrigger("CLOSE");
        StartCoroutine(MakeFalseObject(ContactButton));

        

        infoVRButton.GetComponent<VirtualButtonBehaviour>().enabled = true;
        ConVRButton.GetComponent<VirtualButtonBehaviour>().enabled = true;
        VidVRButton.GetComponent<VirtualButtonBehaviour>().enabled = true;

        closecon.SetActive(false);

        BGAudioSource.Play();

        BGcontact.SetActive(false);

        DisableARbuttonText.SetActive(false);
        AciveARbuttonText.SetActive(true);

        sound = true;
    }

    public void resetvideo()
    {

        VideoPlayObject.SetActive(false);

        infoVRButton.GetComponent<VirtualButtonBehaviour>().enabled = true;
        ConVRButton.GetComponent<VirtualButtonBehaviour>().enabled = true;
        VidVRButton.GetComponent<VirtualButtonBehaviour>().enabled = true;

        closevid.SetActive(false);

        BGAudioSource.Play();

        NSULogo.SetActive(true);

        DisableARbuttonText.SetActive(false);
        AciveARbuttonText.SetActive(true);
        sound = true;
    }





    IEnumerator MakeFalseObject(GameObject x)
    {
        
        yield return new WaitForSeconds(2.5f);

        x.SetActive(false);
       

    }

    IEnumerator DelayBiosoound()
    {

        yield return new WaitForSeconds(2.5f);
        BioAudio.SetActive(true);



    }

    IEnumerator Delaycontactsound()
    {

        yield return new WaitForSeconds(2.5f);
        BGcontact.SetActive(true);



    }



    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    
}
