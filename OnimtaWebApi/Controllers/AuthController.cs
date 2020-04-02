using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.ApplicationUser;
using OnimtaWebInventory.Models;
using SignalRHub;

namespace OnimtaWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {

        private IApplicationUserServices _ApplicationUserServices;
        private ILogger<AuthController> _logger;

        public AuthController(IApplicationUserServices ApplicationUserServices, ILogger<AuthController> logger)
        {

            _ApplicationUserServices = ApplicationUserServices;
            _logger = logger;

        }


        [HttpGet("{userName},{password}")]
        public async Task<ApplicationUserResponse> Login(string userName,string password)
        {
            
            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            IEnumerable<ApplicationUserVM> applicationUserVM;
            try
            {

                applicationUserVM = new List<ApplicationUserVM> {

                   await _ApplicationUserServices.GetApplicationUserDetails(userName,password)
                };

           
               applicationUserResponse.applicationUserVM = applicationUserVM;
                applicationUserResponse.IsSuccess = true;

                if((applicationUserResponse.IsSuccess)) 
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@OnimtaIt"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var claims = new List<Claim>
                    {
                        new Claim("userName", userName),
                        new Claim("password", password)
                    };


                    var tokeOptions = new JwtSecurityToken(
                        issuer: "Onimta-IT",
                       
                        audience: "http://192.168.1.60:4210",
                        claims: claims,
                        expires: DateTime.Now.AddSeconds(30),
                        signingCredentials: signinCredentials
                    );



                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                    applicationUserResponse.applicationUserVM.ElementAt(0).Token = tokenString;
                } else
                {
                   
                }

               
            }

            catch (Exception exc)
            {

               _logger.LogError(exc.Message);
                applicationUserResponse.IsSuccess = false;
                applicationUserResponse.Message = exc.Message;

            }

            return applicationUserResponse;
        }


        [HttpGet("{userName},{password}")]
        public async Task<ApplicationUserResponse> GetRefreshToken(string userName, string password)
        {

            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            IEnumerable<ApplicationUserVM> applicationUserVM;
            try
            {

                applicationUserVM = new List<ApplicationUserVM> {

                   await _ApplicationUserServices.GetRefreshToken(userName,password)
                };


                applicationUserResponse.applicationUserVM = applicationUserVM;
                applicationUserResponse.IsSuccess = true;

                if ((applicationUserResponse.IsSuccess))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@OnimtaIt"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var claims = new List<Claim>
                    {
                        new Claim("userName", userName),
                        new Claim("password", password)
                    };


                    var tokeOptions = new JwtSecurityToken(
                        issuer: "Onimta-IT",
                        
                        audience: "http://192.168.1.60:4210",
                        claims: claims,
                        expires: DateTime.Now.AddSeconds(20),
                        
                        signingCredentials: signinCredentials
                    );



                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                    applicationUserResponse.applicationUserVM.ElementAt(0).Token = tokenString;
                }
                else
                {
                   
                }


            }

            catch (Exception exc)
            {

                _logger.LogError(exc.Message);
                applicationUserResponse.IsSuccess = false;
                applicationUserResponse.Message = exc.Message;

            }

            return applicationUserResponse;
        }

        [HttpGet("{userId}")]
        public async Task<ApplicationUserResponse> DuplicateLogin(int userId)
        {


            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            IEnumerable<ApplicationUserVM> applicationUserVM;
            try
            {

                using (var client = new HttpClient())
                {
                    MessageVM messageVm = new MessageVM();
                    messageVm.ReferenceUserId = userId;
                    var myContent = JsonConvert.SerializeObject(messageVm);
                    var stringContent = new StringContent(myContent.ToString(), UnicodeEncoding.UTF8, "application/json");
                    client.BaseAddress = new Uri("http://localhost:60841/api/");
                    // client.BaseAddress = new Uri("http://192.168.1.7:4206/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsync("UserManagement/Post", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                    }


                }

            }

            catch (Exception exc)
            {

                _logger.LogError(exc.Message);
                applicationUserResponse.IsSuccess = false;
                applicationUserResponse.Message = exc.Message;

            }

            return applicationUserResponse;
        }

        [HttpGet]
        public  string GetToken()
        {

                  string jwtToken = "";

            try
            {
                     
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@OnimtaIt"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                 


                var tokeOptions = new JwtSecurityToken(
                        issuer: "Onimta-IT",
                        audience: "http://localhost:4200",
                      
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );

                jwtToken = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            }

            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
             

            }

            return jwtToken;
        }

    }
}