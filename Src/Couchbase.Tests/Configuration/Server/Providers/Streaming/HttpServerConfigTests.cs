﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Configuration.Client;
using Couchbase.Configuration.Server;
using Couchbase.Configuration.Server.Providers.Streaming;
using NUnit.Framework;

namespace Couchbase.Tests.Configuration.Server.Providers.Streaming
{
    [TestFixture]
    public class HttpServerConfigTests
    {
        private ClientConfiguration _clientConfig;
        private IServerConfig _serverConfig;
        private string _serverIp;

        [OneTimeSetUp]
        public void SetUp()
        {
            _serverIp = ConfigurationManager.AppSettings["serverIp"];
            _clientConfig = new ClientConfiguration();
            _clientConfig.Servers.Add(new Uri(string.Format("http://{0}:8091/pools/", _serverIp)));

            _serverConfig = new HttpServerConfig(_clientConfig, "default", "default", string.Empty);
            _serverConfig.Initialize();
        }

        [Test]
        public void Test_Bootstrap_Is_Not_Null()
        {
            Assert.IsNotNull(_serverConfig.Bootstrap);
        }

        [Test]
        public void Test_Pools_Is_Not_Null()
        {
            Assert.IsNotNull(_serverConfig.Pools);
        }

        [Test]
        public void Test_Buckets_Is_Not_Null()
        {
            Assert.IsNotNull(_serverConfig.Buckets);
        }

        [Test]
        public void Test_StreamingHttp_Is_Null()
        {
            Assert.IsNull(_serverConfig.StreamingHttp);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _serverConfig.Dispose();
        }
    }
}

#region [ License information          ]

/* ************************************************************
 *
 *    @author Couchbase <info@couchbase.com>
 *    @copyright 2014 Couchbase, Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 * ************************************************************/

#endregion