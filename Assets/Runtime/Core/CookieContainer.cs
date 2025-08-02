using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        public int? maxAge; // null means not set, 0+ means seconds from creation
        public DateTime createdAt; // When the cookie was created/received
        public bool httpOnly;
        public bool secure;
        public string sameSite;

        public Cookie(string name, string value, string domain = "", string path = "/")
        {
            this.name = name;
            this.value = value;
            this.domain = domain;
            this.path = path;
            this.expires = DateTime.MaxValue;
            this.maxAge = null; // Not set by default
            this.createdAt = DateTime.Now;
        }

        public bool IsExpired 
        { 
            get
            {
                // max-age has priority over expires according to RFC 6265
                if (maxAge.HasValue)
                {
                    // If maxAge is 0 or negative, cookie should be deleted immediately
                    if (maxAge.Value <= 0)
                        return true;
                    
                    // Check if cookie has exceeded its max-age from creation time
                    return DateTime.Now > createdAt.AddSeconds(maxAge.Value);
                }
                
                return DateTime.Now > expires;
            }
        }

        public bool MatchesDomain(string requestDomain)
        {
            if (string.IsNullOrEmpty(domain))
            {
                return true;
            }
            
            // Normalize domains to lowercase for comparison
            var normalizedDomain = domain.ToLowerInvariant();
            var normalizedRequestDomain = requestDomain.ToLowerInvariant();
            
            // Exact match
            if (normalizedRequestDomain == normalizedDomain)
            {
                return true;
            }
            
            // Domain with leading dot should match subdomains
            if (normalizedDomain.StartsWith("."))
            {
                return normalizedRequestDomain.EndsWith(normalizedDomain) || 
                       normalizedRequestDomain == normalizedDomain.Substring(1);
            }
            
            // Domain without leading dot should match exact or as subdomain
            return normalizedRequestDomain == normalizedDomain || 
                   normalizedRequestDomain.EndsWith("." + normalizedDomain);
        }

        public bool MatchesPath(string requestPath)
        {
            if (string.IsNullOrEmpty(path))
            {
                return true;
            }
            
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
        
        private const string CookiePrefsKey = "Appwrite_Cookies";

        /// <summary>
        /// Add a cookie to the container
        /// </summary>
        public void AddCookie(Cookie cookie)
        {
            if (cookie == null || string.IsNullOrEmpty(cookie.name))
            {
                return;
            }

            // Remove existing cookie with same name, domain, and path
            _cookies.RemoveAll(c => c.name == cookie.name && c.domain == cookie.domain && c.path == cookie.path);
            
            if (!cookie.IsExpired)
            {
                _cookies.Add(cookie);
                SaveCookies(); // Auto-save when cookie is added
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
            {
                return string.Empty;
            }

            return string.Join("; ", cookies.Select(c => c.ToString()));
        }

        /// <summary>
        /// Parse Set-Cookie header and add to container
        /// </summary>
        public void ParseSetCookieHeader(string setCookieHeader, string domain)
        {
            if (string.IsNullOrWhiteSpace(setCookieHeader) || string.IsNullOrWhiteSpace(domain))
            {
                return;
            }

            var parts = setCookieHeader.Split(';');
            if (parts.Length == 0)
            {
                return;
            }

            var nameValue = parts[0].Split(new char[] { '=' }, 2);
            if (nameValue.Length != 2 || string.IsNullOrWhiteSpace(nameValue[0]))
            {
                return;
            }

            var cookie = new Cookie(nameValue[0].Trim(), nameValue[1].Trim(), domain.ToLowerInvariant());

            for (int i = 1; i < parts.Length; i++)
            {
                var part = parts[i].Trim();
                if (string.IsNullOrEmpty(part))
                {
                    continue;
                }
                
                var keyValue = part.Split(new char[] { '=' }, 2);
                var attributeName = keyValue[0].Trim().ToLowerInvariant();
                
                switch (attributeName)
                {
                    case "domain":
                        if (keyValue.Length > 1 && !string.IsNullOrWhiteSpace(keyValue[1]))
                        {
                            cookie.domain = keyValue[1].Trim().ToLowerInvariant();
                        }
                        break;
                    case "path":
                        if (keyValue.Length > 1 && !string.IsNullOrWhiteSpace(keyValue[1]))
                        {
                            cookie.path = keyValue[1].Trim();
                        }
                        break;
                    case "expires":
                        if (keyValue.Length > 1 && DateTime.TryParse(keyValue[1].Trim(), out var expires))
                        {
                            cookie.expires = expires;
                        }
                        break;
                    case "max-age":
                        if (keyValue.Length > 1 && int.TryParse(keyValue[1].Trim(), out var maxAge))
                        {
                            cookie.maxAge = maxAge;
                        }
                        break;
                    case "httponly":
                        cookie.httpOnly = true;
                        break;
                    case "secure":
                        cookie.secure = true;
                        break;
                    case "samesite":
                        if (keyValue.Length > 1 && !string.IsNullOrWhiteSpace(keyValue[1]))
                        {
                            var sameSiteValue = keyValue[1].Trim().ToLowerInvariant();
                            if (sameSiteValue == "strict" || sameSiteValue == "lax" || sameSiteValue == "none")
                            {
                                cookie.sameSite = sameSiteValue;
                            }
                        }
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
            SaveCookies(); // Auto-save when cookies are cleared
        }

        /// <summary>
        /// Get the total number of cookies in the container
        /// </summary>
        public int Count
        {
            get
            {
                CleanExpiredCookies();
                return _cookies.Count;
            }
        }

        /// <summary>
        /// Remove expired cookies
        /// </summary>
        private void CleanExpiredCookies()
        {
            _cookies.RemoveAll(c => c.IsExpired);
        }

        /// <summary>
        /// Load cookies from persistent storage
        /// </summary>
        public void LoadCookies()
        {
            try
            {
                if (PlayerPrefs.HasKey(CookiePrefsKey))
                {
                    var json = PlayerPrefs.GetString(CookiePrefsKey);
                    if (!string.IsNullOrEmpty(json))
                    {
                        var cookieData = JsonSerializer.Deserialize<List<Cookie>>(json);
                        if (cookieData != null)
                        {
                            _cookies = cookieData;
                            CleanExpiredCookies(); // Remove any expired cookies on load
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"Failed to load cookies: {ex.Message}");
                _cookies = new List<Cookie>();
            }
        }

        /// <summary>
        /// Save cookies to persistent storage
        /// </summary>
        public void SaveCookies()
        {
            try
            {
                CleanExpiredCookies(); // Clean before saving
                var json = JsonSerializer.Serialize(_cookies, new JsonSerializerOptions 
                { 
                    WriteIndented = false  // Compact JSON for PlayerPrefs
                });
                PlayerPrefs.SetString(CookiePrefsKey, json);
                PlayerPrefs.Save();
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"Failed to save cookies: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete persistent cookie storage
        /// </summary>
        public void DeleteCookieStorage()
        {
            try
            {
                if (PlayerPrefs.HasKey(CookiePrefsKey))
                {
                    PlayerPrefs.DeleteKey(CookiePrefsKey);
                    PlayerPrefs.Save();
                }
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"Failed to delete cookie storage: {ex.Message}");
            }
        }
    }
}
