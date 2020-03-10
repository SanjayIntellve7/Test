using CustomLogContracts;
using IntellveDashboard.UI.Extensions;
using IntellveDashboard.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IntellveDashboard.UI.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ILoggerManager _logger;
        private readonly JsonServicesHelper _JsonServicesHelper;
        private readonly IOptions<ConfigSettingsModel> _settings;

        private Guid guidOutput;

        public LoginModel(ILoggerManager logger, JsonServicesHelper jsonServicesHelper, IOptions<ConfigSettingsModel> settings)
        {
           

            _logger = logger;
            _JsonServicesHelper = jsonServicesHelper;
            _settings = settings; 
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username/Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            // Clear the existing external cookie
            #region snippet2
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            #endregion

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            if (Input.Email.IndexOf('@') > -1)
            {
                //Validate email format
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                       @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(Input.Email))
                {
                    ModelState.AddModelError("Email", "Email is not valid");
                }
            }
            else
            {
                //validate Username format
                string emailRegex = @"^[a-zA-Z0-9]*$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(Input.Email))
                {
                    ModelState.AddModelError("Email", "Username is not valid");
                }
            }

            if (ModelState.IsValid)
            {
                // Use Input.Email and Input.Password to authenticate the user
                // with your custom authentication logic.
                //
                // For demonstration purposes, the sample validates the user
                // on the email address maria.rodriguez@contoso.com with 
                // any password that passes model validation.

                 
                var user = await AuthenticateUser(Input.Email, Input.Password);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }

                #region snippet1
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email), 
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(CustomClaimTypes.Token, user.Token.ToString()),
                    new Claim(CustomClaimTypes.Identifier, user.Identifier),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                #endregion

                _logger.LogInfo($"User {user.Email} logged in at {DateTime.UtcNow}.");

                return LocalRedirect(Url.GetLocalUrl(returnUrl));
            }

            // Something failed. Redisplay the form.
            return Page();
        }

        private async Task<ApplicationUser> AuthenticateUser(string email, string password)
        {
            // For demonstration purposes, authenticate a user
            // with a static email address. Ignore the password.
            // Assume that checking the database takes 500ms

            await Task.Delay(500);

            string strRetVal = "";
            string strRetVal_getoperation = "";

            try
            {
                _JsonServicesHelper._IsPrimaryAtive = true;
                if (ModelState.IsValid)
                { 
                    var machineIdentifier = Environment.MachineName + "_WebClient_Dashboard";
                    var identifierIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString(); 
                    var CreateSession_URL = _JsonServicesHelper.GetSerivcePath("AuthService", "CreateSession", "identifier=" + machineIdentifier + "&systemId=0&username=" + email + "&password=" + password + "&identifierIP=" + identifierIP + "&component=" + "WebClient_Dashboard");

                    //ServerIpConfigurationModel _ServerIpConfigurationModel = new ServerIpConfigurationModel();
                    //_ServerIpConfigurationModel.AutherizationServiceIp = _configuration.GetSection("BROKER_SERVICE_HOSTS.AutherizationServiceIp").ToString();

                    using (var client_authunticate = new HttpClient())
                    {
                        try
                        {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls; 

                            //HttpContent content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("URL", CreateSession_URL) }); //support application/x-www-form-urlencoded

                            var content = new StringContent(JsonConvert.SerializeObject(CreateSession_URL), Encoding.UTF8, "application/json");//support application/json

                            var response = await client_authunticate.PostAsync(new Uri(_settings.Value.web_API_SERVICE_HOSTS.dashboard_WEB_API_HOST + "/api/Auth/GetServiceUrlResult"), content);

                            if (response.IsSuccessStatusCode)
                                strRetVal = response.Content.ReadAsStringAsync().Result;

                            //returned either service("<guid>") or {"d":"<guid>"}
                            //var result = strRetVal.Split('(', ')')[1];
                            //var guid = StringExtensions.clean(strRetVal);
                            //bool isValid = Guid.TryParse(guid, out guidOutput);

                            if (strRetVal != "")
                            {
                                var result = strRetVal.Substring(6, strRetVal.Length - 8).Replace("\\", "");
                                var guid = StringExtensions.clean(result);
                                bool isValid = Guid.TryParse(guid, out guidOutput);

                                if (isValid)
                                {
                                    var GetUserRoleURL = _JsonServicesHelper.GetSerivcePath("SecurityGetOperationService", "GetUserRole", "authToken=" + guidOutput);

                                    //HttpContent rolecontent = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("URL", GetUserRoleURL) });//support application/x-www-form-urlencoded

                                    var rolecontent = new StringContent(JsonConvert.SerializeObject(GetUserRoleURL), Encoding.UTF8, "application/json");//support application/json

                                    using (var client_getoperation = new HttpClient())
                                    {
                                        var response_getoperation = await client_getoperation.PostAsync(new Uri(_settings.Value.web_API_SERVICE_HOSTS.dashboard_WEB_API_HOST + "/api/Auth/GetServiceUrlResult"), rolecontent);
                                        if (response_getoperation.IsSuccessStatusCode)
                                            strRetVal_getoperation = response_getoperation.Content.ReadAsStringAsync().Result;
                                    }

                                    //var role_result = strRetVal_getoperation.Split('(', ')')[1];
                                    //var user_role = JsonConvert.DeserializeObject<Dictionary<string, string>>(Regex.Unescape(role_result)); 

                                    var role = strRetVal_getoperation.Substring(8, strRetVal_getoperation.Length - 10).Replace("\\", "");
                                    var user_role = StringExtensions.clean(role);

                                    return new ApplicationUser()
                                    {
                                        Email = email,
                                        FullName = email,
                                        //Role = (string)user_role["GetUserRoleResult"], 
                                        Role = (string)user_role,
                                        Token = guidOutput,
                                        Identifier = machineIdentifier
                                    };
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError("Exception Ocurred " + ex.Message);
                            return null;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Ocurred " + ex.Message);
                return null;
            }
        }
    }
}
