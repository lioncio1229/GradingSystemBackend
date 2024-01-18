using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using GradingSystemBackend.Repositories;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace GradingSystemBackend.Middlewares
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
        {
            context.Response.ContentType = "application/json";

            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var jti = GetJtiFromToken(token);

            if (!await IsTokenValid(unitOfWork, jti))
            {
                var response = new DefaultExceptionResponse{
                    Message = "Token is invalid or has expired." 
                };

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                return;
            }

            await _next(context);
        }

        private string? GetJtiFromToken(string token)
        {
            try
            {
                if(!token.IsNullOrEmpty())
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                    if (securityToken != null)
                    {
                        var jtiClaim = securityToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Jti);
                        if (jtiClaim != null)
                        {
                            return jtiClaim.Value;
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<bool> IsTokenValid(IUnitOfWork unitOfWork, string jti)
        {
            var token = await unitOfWork.BlacklistedTokenRepository.Get(o => o.Jti == jti);
            return token == null;
        }
    }
}