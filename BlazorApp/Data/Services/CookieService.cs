using System.Text.RegularExpressions;

namespace BlazorApp.Data.Services{
    public class CookieService : ICookieService{
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor){
            this._httpContextAccessor = httpContextAccessor;
        }

        public void AddCookie(string key, string value, int? time){

            CookieOptions options = new CookieOptions();

            if(time.HasValue){
                options.Expires = DateTime.Now.AddMinutes(time.Value);
            } else{
                options.Expires = DateTime.Now.AddDays(1);
            }

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);
        }

        public string GetCookie(string key){
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }

        public void RemoveCookie(string key){
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
    }
}