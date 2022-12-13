using System;
using Unity.Notifications.Android;
using UnityEngine;

namespace Notification
{
    public class NotificationManager : MonoBehaviour
    {
        private static readonly string CHANNEL_ID = "channel_id";
        
        private void Awake()
        {
            InitializeAndroidNotificationChannel();
        }

        private void InitializeAndroidNotificationChannel()
        {
            AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel ()
            {
                Id = CHANNEL_ID,
                Name = "Default Channel",
                Importance = Importance.Default,
                Description = "Generic notifications"
            };

            AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                SendPauseNotification();
            }
        }

        private void SendPauseNotification()
        {
            AndroidNotification androidNotification = new AndroidNotification ()
            {
                Title = "Hello!",
                Text = "Come back and play Fruit Slicer!",
                FireTime = DateTime.Now.AddSeconds(20.0)
            };
            
            AndroidNotificationCenter.CancelNotification((int)NotificationID.PauseNotification);
            AndroidNotificationCenter.SendNotificationWithExplicitID(androidNotification, CHANNEL_ID, (int)NotificationID.PauseNotification);
        }

        public void SendSettingsButtonNotification()
        {
            AndroidNotification androidNotification = new AndroidNotification ()
            {
                Title = "Settings button tapped",
                Text = "Here is my notifcation for you to KEEP PLAYING :)",
                FireTime = DateTime.Now.AddSeconds(2.0)
            };

            AndroidNotificationCenter.CancelNotification((int)NotificationID.SettingsButtonNotification);
            AndroidNotificationCenter.SendNotification(androidNotification, CHANNEL_ID);
        }
    }
}