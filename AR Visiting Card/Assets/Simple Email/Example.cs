using UnityEngine;
using System.ComponentModel;
using UnityEngine.UI;
using System;

public class Example : MonoBehaviour {

    bool triggerResultEmail= false;
    bool resultEmailSucess;

    public Text resultText;

    public InputField SMTPClient;
    public InputField SMTPPort;
    public InputField UserName;
    public InputField UserPass;
    public InputField To;
    public InputField Subject;
    public InputField Body;
    public InputField AttachFile;

    void Start () {
        SMTPClient.text = PlayerPrefs.GetString("SMTPClient");
        SMTPPort.text = PlayerPrefs.GetString("SMTPPort");
        UserName.text = PlayerPrefs.GetString("UserName");
        UserPass.text = PlayerPrefs.GetString("UserPass");
        To.text = PlayerPrefs.GetString("To");
        Subject.text = PlayerPrefs.GetString("Subject");
        Body.text = PlayerPrefs.GetString("Body");
        AttachFile.text = PlayerPrefs.GetString("AttachFile");
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("SMTPClient", SMTPClient.text);
        PlayerPrefs.SetString("SMTPPort", SMTPPort.text);
        PlayerPrefs.SetString("UserName", UserName.text);
        PlayerPrefs.SetString("UserPass", UserPass.text);
        PlayerPrefs.SetString("To", To.text);
        PlayerPrefs.SetString("Subject", Subject.text);
        PlayerPrefs.SetString("Body", Body.text);
        PlayerPrefs.SetString("AttachFile", AttachFile.text);

        PlayerPrefs.Save();
    }

    public void sendEmail()
    {
        SimpleEmailSender.emailSettings.STMPClient = SMTPClient.text.Trim();
        SimpleEmailSender.emailSettings.SMTPPort = Int32.Parse(SMTPPort.text.Trim());
        SimpleEmailSender.emailSettings.UserName = UserName.text.Trim();
        SimpleEmailSender.emailSettings.UserPass = UserPass.text.Trim();

        SimpleEmailSender.Send(To.text, Subject.text, Body.text, AttachFile.text, SendCompletedCallback);
    }

    private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled || e.Error != null)
        {
            print("Email not sent: " + e.Error.ToString());

            resultEmailSucess = false;
            triggerResultEmail = true;
        }
        else
        {
            print("Email successfully sent.");

            resultEmailSucess = true;
            triggerResultEmail = true;
        }
    }
}
