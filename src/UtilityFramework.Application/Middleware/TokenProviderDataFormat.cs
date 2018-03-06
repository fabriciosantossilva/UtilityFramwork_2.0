using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UtilityFramework.Application.Middleware
{
    public class TokenProviderDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string _algorithm;
        private readonly TokenValidationParameters _validationParameters;

        public TokenProviderDataFormat(string algorithm, TokenValidationParameters validationParameters)
        {
            _algorithm = algorithm;
            _validationParameters = validationParameters;
        }

        public AuthenticationTicket Unprotect(string protectedText)
            => Unprotect(protectedText, null);

        public AuthenticationTicket Unprotect(string protectedText, string purpose)
        {
            var handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = null;

            try
            {
                principal = handler.ValidateToken(protectedText, _validationParameters, out var validToken);

                if (!(validToken is JwtSecurityToken validJwt))

                    throw new ArgumentException("Invalid JWT");

                if (!validJwt.Header.Alg.Equals(_algorithm, StringComparison.Ordinal))
                    throw new ArgumentException($"Algorithm must be '{_algorithm}'");
                // Additional custom validation of JWT claims here (if any)
            }
            catch (SecurityTokenValidationException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }

            // Validation passed. Return a valid AuthenticationTicket:
            return new AuthenticationTicket(principal, new AuthenticationProperties(), "Cookie");
        }

        // This ISecureDataFormat implementation is decode-only
        public string Protect(AuthenticationTicket data)
        {
            throw new NotImplementedException();
        }

        public string Protect(AuthenticationTicket data, string purpose)
        {
            throw new NotImplementedException();
        }
    }

    public class AddRequiredHeaderParameter : IOperationFilter
    {
        void IOperationFilter.Apply(Operation operation, OperationFilterContext context)
        {

            // verify if request contains attribute allowanon
            if (context.ApiDescription.ActionAttributes().OfType<AllowAnonymousAttribute>().Any()) return;
            if (!context.ApiDescription.ControllerAttributes().OfType<AuthorizeAttribute>().Any()) return;

            var param = new Param();
            param.Name = "Authorization";
            param.In = "header";
            param.Description = "bearer + Jwt Token";
            param.Required = true;
            param.Type = "string";
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();
            operation.Parameters.Insert(0, param);
        }

        private class Param : IParameter
        {

            public string Description { get; set; }

            public Dictionary<string, object> Extensions => new Dictionary<string, object> { { "test", true } };

            public string In { get; set; }

            public string Name { get; set; }

            public string Type { get; set; }

            public bool Required { get; set; }
        }
    }
    public static class Helper
    {
        /// <summary>
        /// obtem token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetUserId(this HttpRequest request)
        {
            request.Headers.TryGetValue("Authorization", out var token);

            if (string.IsNullOrEmpty(token)) return null;

            var array = token.ToString().Split(' ');

            token = array.Length > 1 ? array[1].Trim() : null;

            return !string.IsNullOrEmpty(token) ? new JwtSecurityToken(token)?.Subject : null;
        }
    }


}
