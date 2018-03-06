using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace UtilityFramework.Application.Core.JwtMiddleware
{
    /// <summary>
    /// Token generator middleware component which is added to an HTTP pipeline.
    /// This class is not created by application code directly,
    /// instead it is added by calling the <see cref="TokenProviderAppBuilderExtensions.UseSimpleTokenProvider"/>
    /// extension method.
    /// </summary>
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;

        private static TokenProviderOptions _options;
        public TokenProviderMiddleware(IOptions<TokenProviderOptions> options, RequestDelegate next)
        {
            _next = next;
            _options = options.Value;
            ThrowIfInvalidOptions(_options);
        }


        public Task Invoke(HttpContext context)
        {
            return _next(context);
        }
        
        /// <summary>
        /// GERATE TOKEN AND REFRESH TOKEN PROFILE
        /// </summary>
        /// <param name="profileId">IDENTIFIER PROFILE</param>
        /// <param name="path">PATH API OFF TOKEN</param>
        /// <param name="refreshToken">DEFAULT FALSE</param>
        /// <param name="expireToken">EXPIRE TOKEN</param>
        /// <param name="expireRefresh">EXPIRE REFRESH TOKEN</param>

        /// <returns></returns>
        public static object GenerateToken(string profileId, string path = "/api/v1/Profile/Token", bool refreshToken = false,TimeSpan? expireToken = null,TimeSpan? expireRefresh = null)
        {
            try
            {
                var now = DateTime.UtcNow;

                if(expireRefresh == null){
                  expireRefresh = TimeSpan.FromHours(2);
                }
                   
                if(expireToken == null)
                   expireToken = _options.Expiration;

                var claims = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub, profileId),
                        new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64)
                    };

                var expire = !refreshToken
                    ? now.Add(expireToken.GetValueOrDefault())
                    : now.Add(_options.Expiration).Add(expireRefresh.GetValueOrDefault());

                // Create the JWT and write it to a string
                var jwt = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    notBefore: now,
                    expires: expire,
                    signingCredentials: _options.SigningCredentials);

                // Create the JWT and write it to a string
                var jwtRefresh = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(_options.Expiration.Add(TimeSpan.FromHours(2))),
                    signingCredentials: _options.SigningCredentials);

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var encodedJwtRefresh = new JwtSecurityTokenHandler().WriteToken(jwtRefresh);

                var response = new
                {
                    access_token = encodedJwt,
                    refresh_token = encodedJwtRefresh,
                    expires_in = (int)_options.Expiration.TotalSeconds,
                    expires = $"{DateTime.Now.AddSeconds(_options.Expiration.TotalSeconds):dd/MM/yyyy HH:mm:ss}",
                    expires_type = "seconds",
                };

                // Serialize and return the response
                return response;

            }
            catch (Exception)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Path));

            }
        }

        private static void ThrowIfInvalidOptions(TokenProviderOptions options)
        {
            if (string.IsNullOrEmpty(options.Path))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Path));
            }

            if (string.IsNullOrEmpty(options.Issuer))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Issuer));
            }

            if (string.IsNullOrEmpty(options.Audience))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Audience));
            }

            if (options.Expiration == TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(TokenProviderOptions.Expiration));
            }

            if (options.IdentityResolver == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.IdentityResolver));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.SigningCredentials));
            }

            if (options.NonceGenerator == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.NonceGenerator));
            }
        }

        /// <summary>
        /// Get this datetime as a Unix epoch timestamp (seconds since Jan 1, 1970, midnight UTC).
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>Seconds since Unix epoch.</returns>
        private static long ToUnixEpochDate(DateTime date) => new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds();
    }
}
