using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Appwrite
{
    /// <summary>
    /// Simple cookie container for Unity WebRequest
    /// </summary>
    [Serializable]
    public class Cookie
    {
        public string name;
        public string value;
        public string domain;
        public string path;
        public DateTime expires;
        public bool httpOnly;
        public bool secure;

        public Cookie(string name, string value, string domain = "", string path = "/")
        {
            this.name = name;
            this.value = value;
            this.domain = domain;
            this.path = path;
            this.expires = DateTime.MaxValue;
        }

        public bool IsExpired => DateTime.Now > expires;

        public bool MatchesDomain(string requestDomain)
        {
            if (string.IsNullOrEmpty(domain))
                return true;
            
            return requestDomain.EndsWith(domain, StringComparison.OrdinalIgnoreCase);
        }

        public bool MatchesPath(string requestPath)
        {
            if (string.IsNullOrEmpty(path))
                return true;
            
            return requestPath.StartsWith(path, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"{name}={value}";
        }
    }

    /// <summary>
    /// Simple cookie container implementation for Unity
    /// </summary>
    [Serializable]
    public class CookieContainer
    {
        [SerializeField]
        private List<Cookie> _cookies = new List<Cookie>();

        /// <summary>
        /// Add a cookie to the container
        /// </summary>
        public void AddCookie(Cookie cookie)
        {
            if (cookie == null || string.IsNullOrEmpty(cookie.name))
                return;

            // Remove existing cookie with same name and domain
            _cookies.RemoveAll(c => c.name == cookie.name && c.domain == cookie.domain);
            
            if (!cookie.IsExpired)
            {
                _cookies.Add(cookie);
            }
        }

        /// <summary>
        /// Get cookies for a specific domain and path
        /// </summary>
        public List<Cookie> GetCookies(string domain, string path = "/")
        {
            CleanExpiredCookies();
            
            return _cookies.Where(c => 
                c.MatchesDomain(domain) && 
                c.MatchesPath(path) && 
                !c.IsExpired
            ).ToList();
        }

        /// <summary>
        /// Get cookie header string for request
        /// </summary>
        public string GetCookieHeader(string domain, string path = "/")
        {
            var cookies = GetCookies(domain, path);
            if (cookies.Count == 0)
                return string.Empty;

            return string.Join("; ", cookies.Select(c => c.ToString()));
        }

        /// <summary>
        /// Parse Set-Cookie header and add to container
        /// </summary>
        public void ParseSetCookieHeader(string setCookieHeader, string domain)
        {
            if (string.IsNullOrEmpty(setCookieHeader))
                return;

            var parts = setCookieHeader.Split(';');
            if (parts.Length == 0)
                return;

            var nameValue = parts[0].Split('=');
            if (nameValue.Length != 2)
                return;

            var cookie = new Cookie(nameValue[0].Trim(), nameValue[1].Trim(), domain);

            for (int i = 1; i < parts.Length; i++)
            {
                var part = parts[i].Trim();
                var keyValue = part.Split('=');
                
                switch (keyValue[0].ToLower())
                {
                    case "domain":
                        if (keyValue.Length > 1)
                            cookie.domain = keyValue[1];
                        break;
                    case "path":
                        if (keyValue.Length > 1)
                            cookie.path = keyValue[1];
                        break;
                    case "expires":
                        if (keyValue.Length > 1 && DateTime.TryParse(keyValue[1], out var expires))
                            cookie.expires = expires;
                        break;
                    case "httponly":
                        cookie.httpOnly = true;
                        break;
                    case "secure":
                        cookie.secure = true;
                        break;
                }
            }

            AddCookie(cookie);
        }

        /// <summary>
        /// Clear all cookies
        /// </summary>
        public void Clear()
        {
            _cookies.Clear();
        }

        /// <summary>
        /// Remove expired cookies
        /// </summary>
        private void CleanExpiredCookies()
        {
            _cookies.RemoveAll(c => c.IsExpired);
        }
    }
}
