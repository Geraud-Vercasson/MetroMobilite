using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using Transports;

namespace MetroMobiliteTest
{
    [TestClass]
    public class MetroMobiliteTest
    {
        private MockFactory _mockFactory;
        private Mock<IStationsProvider> _mockStationProvider;

        [TestInitialize]
        public void Setup()
        {
            _mockFactory = new MockFactory();
            _mockStationProvider = _mockFactory.CreateMock<IStationsProvider>();
        }

        [TestCleanup]
        public void TearDown()
        {
            _mockFactory.VerifyAllExpectationsHaveBeenMet();
            _mockFactory.Dispose();
        }

        [TestMethod]
        public void GetStationsByDistanceReturnsAStationCollection()
        {
            List<string> fakeLines = new List<string>(new string[] { "Test", "Test2" });

            Station fakeStation = new Station("fakeId", "fakeName", 0L, 0L, fakeLines);

            List<Station> mockedList = new List<Station>(new Station[] { fakeStation }); 

            _mockStationProvider.Expects.One.Method(_ => _.GetStationsByDistance(0))
                .With(300)
                .WillReturn(mockedList);

            MetroMobilite test = new MetroMobilite(_mockStationProvider.MockObject);

            Assert.AreEqual(test.GetStationsByDist(300), mockedList);
        }

         [TestMethod]
         public void GetStationsReturnsStationDictionary()
        {
            List<string> fakeLines = new List<string>(new string[] { "Test", "Test2" });

            Station fakeStation = new Station("fakeId", "fakeName", 0L, 0L, fakeLines);

            Dictionary<string, Station> mockedDictionary = new Dictionary<string, Station>();
            mockedDictionary.Add("fakeId", fakeStation);

            _mockStationProvider.Expects.One.Method(_ => _.GetStations(0)).With(0)
                .WillReturn(mockedDictionary);

            MetroMobilite test = new MetroMobilite(_mockStationProvider.MockObject);

            Assert.AreEqual(test.GetStations(0), mockedDictionary);
        }
    }
}
