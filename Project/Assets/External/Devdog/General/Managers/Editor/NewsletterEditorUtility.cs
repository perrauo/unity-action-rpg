using System;
using System.Net;
using UnityEditor;

namespace Devdog.General.Editors
{
    public static class NewsletterEditorUtility
    {
        private const string SignupNewsletterApiUrl = "http://devdog.io/unity/mailchimpsignup.php";
        private const string DevdogNewsletterSignupKey = "DEVDOG_SIGNUP_EMAIL";

        private static string _email;
        public static string subscribedWithEmail
        {
            get
            {
                if (string.IsNullOrEmpty(_email) && EditorPrefs.HasKey(DevdogNewsletterSignupKey))
                {
                    _email = EditorPrefs.GetString(DevdogNewsletterSignupKey);
                }

                return _email;
            }
            private set
            {
                EditorPrefs.SetString(DevdogNewsletterSignupKey, value);
                _email = value;
            }
        }

        public static bool isSubscribedToMailingList
        {
            get { return EditorPrefs.HasKey(DevdogNewsletterSignupKey); }
        }

        /// <summary>
        /// Subscribe an email to the mailing list.
        /// </summary>
        /// <returns>True for success and false when failed.</returns>
        public static bool SubscribeToMailingList(string email, out string result)
        {
            _email = email;
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                result = client.UploadString(new Uri(SignupNewsletterApiUrl + "?email_address=" + email), "POST");
            }

            if (result.Contains("\"status\":\"subscribed\""))
            {
                subscribedWithEmail = _email;
                return true;
            }

            return false;
        }
    }
}
