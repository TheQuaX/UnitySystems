using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchIntegration : MonoBehaviour
{
    [Header("IRC DATA")]
    [SerializeField]
    private IRC _irc;
    [Header("TWITCH STUFF")]
    public float doActionsEverySecond = 0.2f;
    public string nickname, channel, oauth;

    private void Start()
    {
        if (nickname != string.Empty && channel != string.Empty && oauth != string.Empty)
        {
            _irc = new IRC(nickname, channel, oauth);
            StartCoroutine(HandleActionQueue());
        }
        else
        {
            Debug.Log("Login string was empty");
        }
    }

    private void Update()
    {
        if (_irc.activeUsers.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                string[] users = _irc.activeUsers.ToArray();
                foreach (string user in users)
                {
                    Debug.Log(user);
                }
            }
        }

        if (_irc.actions.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                UserAction[] acs = _irc.actions.ToArray();
                foreach (UserAction a in acs)
                {
                    Debug.Log(a.ToString());
                }
            }
        }

    }

    IEnumerator HandleActionQueue()
    {
        yield return new WaitForSeconds(doActionsEverySecond);
        DoAction();
    }

    void DoAction()
    {
        if (_irc.actions.Count > 0)
        {
            UserAction a = _irc.actions.Dequeue();
            Debug.Log("Do action: " + a.Action + " by " + a.Username);
            _irc.SendMessage("[" + a.Action + "] by " + a.Username);
        }
        StartCoroutine(HandleActionQueue());
    }

    private void OnDestroy()
    {
        SaveData();
    }

    void SaveData()
    {
        foreach (string user in _irc.activeUsers)
        {
            PlayerPrefs.SetInt(user, 0);
        }
        PlayerPrefs.Save();
        Debug.Log("Data saved!");
    }
}
