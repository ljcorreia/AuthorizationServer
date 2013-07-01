﻿/*
 * Copyright (c) Dominick Baier, Brock Allen.  All rights reserved.
 * see license.txt
 */

using System.Collections.Generic;
using Thinktecture.AuthorizationServer.Models;

namespace Thinktecture.AuthorizationServer.Interfaces
{
    public interface ITokenHandleManager
    {
        void Add(TokenHandle handle);
        TokenHandle Get(string handleIdentifier);
        TokenHandle Find(string subject, Client client, Application application);
        void Delete(string handleIdentifier);
        
        //IEnumerable<CodeToken> Search(int? clientId, string username, string scope, CodeTokenType type)
    }
}
