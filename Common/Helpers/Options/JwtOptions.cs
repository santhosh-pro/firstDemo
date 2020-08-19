using System;

namespace firstDemo.Common.Helpers.Options
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan TokenLifetime { get; set; }
        public bool ShouldValidateLifeTime { get; set; }
    }
}