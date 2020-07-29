using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    public void Call() {

        Application.OpenURL("tel:+8801643481347");


    }

    public void OpenFacebookProfile() {


        Application.OpenURL("fb://profile/1362175752");



        }

    public void OpenInstaProfile() {

        Application.OpenURL("https://www.instagram.com/pallob_bh");

    }

    public void OpenLinkedinProfile()
    {

        Application.OpenURL("https://www.linkedin.com/in/a-k-m-bahalul-haque/?originalSubdomain=bd");

    }

    public void OpenNSUweb() {

        Application.OpenURL("http://www.northsouth.edu/");

    }


    public void SendEmail()
    {
        string email = "bahalul.haque@northsouth.edu";
        string subject = MyEscapeURL(" ");
        string body = MyEscapeURL(" ");
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }
    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }
}
