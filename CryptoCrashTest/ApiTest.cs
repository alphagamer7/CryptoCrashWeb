namespace CryptoCrashTest;

[TestClass]
public class UnitTest1
{
    public class MockedResponse
        {
            public string? testString { get; set; }
        }

        [TestMethod]
        public void TestApiDeserilization()
        {
            NewsApiClient<MockedResponse> client = new();
            var json = @"{
                          'data': {
                            'upcoming': [
                              {
                                'testString': 'test1'
                              },
                              {
                                'testString': 'test2'
                              },
                                ]
                            }
                         }";
            var res = client.CreateNewsFromJson(json);
            Assert.IsNotNull(res);
            Assert.AreEqual(2, res.Count);
            Assert.AreEqual("test1", res[0].testString);
            Assert.AreEqual("test2", res[1].testString);
        }
//  [TestMethod]
//          public async Task Check_For_Empty_TimeSheetList_TestAsync()
//          {
//              List<TimeSheet> timeSheets = await timesheetViewModel.GetTimeSheets();
//              Assert.IsTrue(timeSheets.Count == 0);
//          }
   
}
