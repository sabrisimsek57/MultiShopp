﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MultiShopp.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> apiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog") {Scopes={"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermisson"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"} },
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"} },
            new ApiResource("ResourceComment"){Scopes={"CommentFullPermission" } },
            new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission" } },
            new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"} },
            new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"} },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
          
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
              new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
              new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
              new ApiScope("DiscountFullPermission","Full authority for discount operations"),
              new ApiScope("OrderFullPermisson","Full authority for order operations"),
              new ApiScope("CargoFullPermission","Full authority for cargo operations"),
              new ApiScope("BasketFullPermission","Full authority for basket operations"),
              new ApiScope("CommentFullPermission","Full authority for comment operations"),
              new ApiScope("PaymentFullPermission","Full authority for payment operations"),
              new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
              new ApiScope("MessageFullPermission","Full authority for message operations"),
              new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //visitor
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "DiscountFullPermission", "CatalogReadPermission","CatalogFullPermission", "OcelotFullPermission", "CommentFullPermission","BasketFullPermission","OrderFullPermisson", "PaymentFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,},
                AllowAccessTokensViaBrowser=true

             },
            //Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogReadPermission", "DiscountFullPermission" ,"CatalogFullPermission", "BasketFullPermission" , "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission" ,"OrderFullPermisson","MessageFullPermission", "CargoFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile }


            },

            //Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermisson","CargoFullPermission","BasketFullPermission","OcelotFullPermission","CommentFullPermission","PaymentFullPermission","MessageFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600
            }
        };

    }
}