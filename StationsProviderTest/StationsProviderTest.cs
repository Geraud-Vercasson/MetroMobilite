using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using Transports;
using Newtonsoft.Json;

namespace StationsProviderTest
{
    /// <summary>
    /// Description résumée pour StationsProviderTest
    /// </summary>
    [TestClass]
    public class StationsProviderTest
    {
        private MockFactory _mockFactory;
        private Mock<IMetroAPICall> _mockMetroAPICall;

        [TestInitialize]
        public void Setup()
        {
            _mockFactory = new MockFactory();
            _mockMetroAPICall = _mockFactory.CreateMock<IMetroAPICall>();
        }

        [TestCleanup]
        public void TearDown()
        {
            _mockFactory.VerifyAllExpectationsHaveBeenMet();
            _mockFactory.Dispose();
        }


        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetStationsByDistanceReturnsStationListFromJSONString()
        {
            string fakeJsonString = "[{\"id\":\"SEM: 1990\",\"name\":\"GRENOBLE, CHAVANT\",\"lon\":5.7312,\"lat\":45.18551,\"lines\":[\"SEM: C1\"]},{\"id\":\"SEM: 0753\",\"name\":\"GRENOBLE, DOCTEUR MARTIN\",\"lon\":5.72686,\"lat\":45.1878,\"lines\":[\"SEM: C1\",\"SEM: 57\",\"SEM: C4\"]}]";
            int dist = 300;
            string sLongitude = "5.7287321", sLatitude = "45.1856964";
            bool details = true;


            string fakeUrl = $"linesNear/json?x={sLongitude}&y={sLatitude}&dist={dist}&details={details}";

            _mockMetroAPICall.Expects.One.Method<List<Station>>(_ => _.Get<List<Station>>(""))
                .With(fakeUrl).WillReturn(JsonConvert.DeserializeObject<List<Station>>(fakeJsonString));

            Station fakeStation1 = new Station("SEM: 1990","GRENOBLE, CHAVANT", Convert.ToDouble("5,7312"), Convert.ToDouble("45,18551"),
                new List<string>(new string[] { "SEM: C1" }));

            Station fakeStation2 = new Station("SEM: 0753", "GRENOBLE, DOCTEUR MARTIN", Convert.ToDouble("5,72686"), Convert.ToDouble("45,1878"),
                new List<string>(new string[] { "SEM: C1", "SEM: 57", "SEM: C4" }));

            List<Station> expectedList = new List<Station>(new Station[] { fakeStation1, fakeStation2 });

            StationsProvider stationsProvider = new StationsProvider(_mockMetroAPICall.MockObject, "5.7287321", "45.1856964", true);

            List<Station> actualList = stationsProvider.GetStationsByDistance(dist);

            for (int i=0; i<expectedList.Count; i++)
            {
                Assert.AreEqual(expectedList[i].id, actualList[i].id);
                Assert.AreEqual(expectedList[i].lat, actualList[i].lat);
                Assert.AreEqual(expectedList[i].lon, actualList[i].lon);
                Assert.AreEqual(expectedList[i].name, actualList[i].name);

                for(int j = 0; j < expectedList[i].lines.Count; j++)
                {
                    Assert.AreEqual(expectedList[i].lines[j], actualList[i].lines[j]);
                }
            }
        }

        [TestMethod]
        public void GetStationsReturnsStationDictionaryFromJSONString()
        {
            string fakeJsonString = "[{\"id\":\"SEM: 1990\",\"name\":\"GRENOBLE, CHAVANT\",\"lon\":5.7312,\"lat\":45.18551,\"lines\":[\"SEM: C1\"]},{\"id\":\"SEM: 1990\",\"name\":\"GRENOBLE, CHAVANT\",\"lon\":5.73177,\"lat\":45.18466,\"lines\":[\"SEM: C1\",\"SEM: C\", \"SEM: A\", \"SEM: E\"]}]";
            int dist = 300;
            string sLongitude = "5.7287321", sLatitude = "45.1856964";
            bool details = true;

            string fakeUrl = $"linesNear/json?x={sLongitude}&y={sLatitude}&dist={dist}&details={details}";

            _mockMetroAPICall.Expects.One.Method<List<Station>>(_ => _.Get<List<Station>>(""))
                .With(fakeUrl).WillReturn(JsonConvert.DeserializeObject<List<Station>>(fakeJsonString));

            Dictionary<string, Station> expected = new Dictionary<string, Station>();
            expected.Add("GRENOBLE, CHAVANT",
                new Station("SEM: 1990", "GRENOBLE, CHAVANT", Convert.ToDouble("5,7312"), Convert.ToDouble("45,18551"),
                new List<string>() { "SEM: C1", "SEM: C", "SEM: A", "SEM: E" }));

            StationsProvider stationsProvider = new StationsProvider(_mockMetroAPICall.MockObject, "5.7287321", "45.1856964", true);

            Dictionary<string, Station> actual = stationsProvider.GetStations(dist);

            Assert.AreEqual(expected["GRENOBLE, CHAVANT"].name, actual["GRENOBLE, CHAVANT"].name);
            Assert.AreEqual(expected["GRENOBLE, CHAVANT"].id, actual["GRENOBLE, CHAVANT"].id);
            Assert.AreEqual(expected["GRENOBLE, CHAVANT"].lon, actual["GRENOBLE, CHAVANT"].lon);
            Assert.AreEqual(expected["GRENOBLE, CHAVANT"].lat, actual["GRENOBLE, CHAVANT"].lat);

            for (int i = 0; i < expected["GRENOBLE, CHAVANT"].lines.Count; i++)
            {
                Assert.AreEqual(expected["GRENOBLE, CHAVANT"].lines[i], actual["GRENOBLE, CHAVANT"].lines[i]);
            }
        }
    }
}
