// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace IdentityServerAspNetIdentity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api1", "My API #1")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
          var spaClientUrl = "https://localhost:4200";

            return new[]
            {
                // client credentials flow client
                new Client
                {
                    ClientId = "client",
                    ClientName = "Client Credentials Client",

                    // no interactive user, use the clientId/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "api1" }
                },

                // MVC client using code flow + pkce
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RequirePkce = true,
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    RedirectUris = { "http://localhost:5003/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:5003/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:5003/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "api1" }
                },
                new Client
                {
                    ClientId = "spaCodeClient",
                    ClientName = "SPA Code Client",
                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 30,
 
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
 
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        $"{spaClientUrl}/callback",
                        $"{spaClientUrl}/silent-renew.html",
                        "https://localhost:4200",
                        "https://localhost:4200/silent-renew.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{spaClientUrl}/unauthorized",
                        $"{spaClientUrl}",
                        "https://localhost:4200/unauthorized",
                        "https://localhost:4200"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        $"{spaClientUrl}",
                        "https://localhost:4200"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "resourceApi"
                    }
                },

                // SPA client using code flow + pkce
                new Client
                {
                    ClientId = "spa",
                    ClientName = "SPA Client",
                    ClientUri = "http://localhost:50823",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris =
                    {
                        "http://localhost:50823/callback.html",
                    },

                    PostLogoutRedirectUris = { "http://localhost:50823/index.html" },
                    AllowedCorsOrigins = { "http://localhost:50823" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                }
            };
        }
    }
}