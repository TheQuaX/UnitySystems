using System;
using System.IO;
using System.Net.Sockets;
using System.Timers;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IRC
{

    #region TCP Data
    private string userName, password, channelName;
    private string chatCommandID, chatMessagePrefix;
    TcpClient tcpClient;
    StreamReader reader;
    StreamWriter writer;
    #endregion

    public List<string> activeUsers;
    public Queue<UserAction> actions;

    public IRC(string nick, string channel, string pw)
    {
        this.userName = nick;
        this.channelName = channel;
        this.password = pw;
        chatCommandID = "PRIVMSG";
        chatMessagePrefix = $":{userName}!{channelName}.tmi.twitch.tv {chatCommandID} #{channelName} :";
        Reconnect();
        activeUsers = new List<string>();
        actions = new Queue<UserAction>();

        //TIMERS
        System.Timers.Timer pingTimer = new System.Timers.Timer(300000);
        pingTimer.AutoReset = true;
        pingTimer.Elapsed += PingTwitch;
        pingTimer.Enabled = true;

        System.Timers.Timer checkOnlineTimer = new System.Timers.Timer(100);
        checkOnlineTimer.AutoReset = true;
        checkOnlineTimer.Elapsed += CheckOnline;
        checkOnlineTimer.Enabled = true;
        Debug.Log("IRC created!");
    }

    void Reconnect()
    {
        Console.WriteLine($"IRC connected to {this.channelName}");
        tcpClient = new TcpClient("irc.twitch.tv", 6667);
        reader = new StreamReader(tcpClient.GetStream());
        writer = new StreamWriter(tcpClient.GetStream());
        writer.AutoFlush = false;

        //Join with name and pw
        writer.WriteLine("PASS " + password + Environment.NewLine + "NICK " + userName + Environment.NewLine + "USER " + userName + " 8 * :" + userName);
        //join channel
        writer.WriteLine("JOIN #" + channelName);
        writer.Flush();
    }

    private void PingTwitch(System.Object source, ElapsedEventArgs e)
    {
        writer.WriteLine("PING irc.twitch.tv");
        writer.Flush();
    }

    private void CheckOnline(System.Object source, ElapsedEventArgs e)
    {
        if (!tcpClient.Connected)
        {
            Reconnect();
        }


        if (tcpClient.Available > 0 || reader.Peek() >= 0)
        {
            var message = reader.ReadLine();
            var iCollon = message.IndexOf(":", 1);
            if (iCollon > 0)
            {
                var command = message.Substring(1, iCollon + 1);

                if (command.Contains(chatCommandID))
                {
                    var isName = command.IndexOf("!");
                    if (isName > 0)
                    {
                        var chattername = command.Substring(0, isName);
                        var chatMessage = message.Substring(iCollon + 1);
                        ReceiveMessage(chattername, chatMessage);

                    }

                }

                if (command.Contains("PING "))
                {
                    writer.WriteLine("PING irc.twitch.tv");
                    writer.Flush();
                }
            }


        }
    }

    private void ReceiveMessage(string chattername, string message)
    {
        //Add new user to activeuserlist
        if (!activeUsers.Contains(chattername.ToLower()))
        {
            activeUsers.Add(chattername);
        }

        if (message.ToLower().StartsWith("!"))
        {
            //Add actions to queue
            actions.Enqueue(new UserAction(chattername, message));
            Debug.Log(chattername + " was using: " + message);
        }
        else
        {
            Debug.Log(chattername + ": " + message);
        }



    }

    public void SendMessage(string message)
    {
        System.Threading.Thread.Sleep(2000);
        writer.WriteLine(chatMessagePrefix + message);
        writer.Flush();
    }
}

[System.Serializable]
public class UserAction
{
    private string username;
    private string action;

    public UserAction(string username, string action)
    {
        this.username = username;
        this.action = action;
    }

    public override string ToString()
    {
        return this.username + ", " + action;
    }

    public string Username { get => username; set => username = value; }
    public string Action { get => action; set => action = value; }
}