namespace BlazorApp.Data.Services{
    public interface ICookieService{
        public void AddCookie(string key, string value, int? time);
        public string GetCookie(string key);
        public void RemoveCookie(string key);
    }
}