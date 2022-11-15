using System;
//using nonexistent;

namespace bmi_test;

public class BmiTests
{
  [Theory]
  [InlineData(0.3048,1.0)]
  [InlineData(1.0,3.28084)]
  public void MetricFootConversions(double expected, double input)
  {
    Assert.Equal(expected,bmi.Foot2meter(input),4);
  }
  [Theory]
  [InlineData(0.0254,1.0)]
  [InlineData(1.0,39.3701)]
  public void MetricInchConversions(double expected, double input)
  {
    Assert.Equal(expected,bmi.Inch2meter(input),4);
  }
  [Theory]
  [InlineData(0.453592,1.0)]
  [InlineData(1.0,2.20462)]
  public void MetricPoundConversions(double expected, double input)
  {
    Assert.Equal(expected,bmi.Pounds2kg(input),4);
  }
  [Theory]
  [InlineData(1.0,1.0)]
  [InlineData(4.0,2.0)]
  [InlineData(9.0,3.0)]
  [InlineData(16.0,4.0)]
  [InlineData(25.0,5.0)]
  public void SquaredTest(double expected,double input)
  {
    Assert.Equal(expected,bmi.Squared(input),4);
  }
  [Theory]
  //[InlineData(2.02, 1.01,"1.01 kg 2.02 cm")]
  [InlineData(2.02, 1.01,"1.01kg 2.02cm")]
  [InlineData(2.02, 1.01,"1.01 2.02")]
  [InlineData(1.8542, 1.01,"1.01")]
  [InlineData(1.8542, 97.0688,"")]
  [InlineData(1.8542, 97.0688,null)]
  public void ParseMetricTest(double expectedWeight,double expectedHeight,string input)
  {
    var actual = bmi.ParseMetric(input);
    Assert.Equal(expectedWeight,actual.Item1,4);
    Assert.Equal(expectedHeight,actual.Item2,4);
  }

  [Theory]
  [InlineData(1.8542, 97.0688, "214lb 6ft 1in")]
  [InlineData(1.8542, 97.0688, "214lb")]
  [InlineData(1.8542, 97.0688, "")]
  [InlineData(1.8542, 97.0688, null)]
  public void ParseImperialTest(double expectedWeight,double expectedHeight,string input)
  {
    var actual = bmi.ParseImperial(input);
    Assert.Equal(expectedWeight,actual.Item1,4);
    Assert.Equal(expectedHeight,actual.Item2,4);
  }

  [Theory]
  [InlineData(new string[]{},"214lb 6ft 1in")]
  [InlineData(new string[]{ "214lb", "6ft", "1in"}, "")]
  public void ParseGetInputs(string[] argv, string line)
  {
    //string[] argv = new string[]{};
    var actual = bmi.GetInputs(argv, (string p) => { return line;} , "Hello");
    var expectedWeight = 1.8542;
    var expectedHeight = 97.0688;
    Assert.Equal(expectedWeight,actual.Item1,4);
    Assert.Equal(expectedHeight,actual.Item2,4);
  }

  [Theory]
  [InlineData(28.2336, 1.8542, 97.0688)]
 public void BmiCalcTest(double expected, double height, double weight)
  {
    var actual = bmi.BmiCalc(height,weight);
    Assert.Equal(expected, actual, 4);
  }

  [Theory]
  [InlineData(28.2336, 214.0, 6.0 + 1.0/12.0)]
  [InlineData(24.5395, 186.0, 6.0 + 1.0/12.0)]
  [InlineData(23.3521, 177.0, 6.0 + 1.0/12.0)]
 public void BmiCalcTest2(double expected, double weight, double height)
  {
    var actual = bmi.BmiCalc(bmi.Foot2meter(height),bmi.Pounds2kg(weight));
    Assert.Equal(expected, actual, 4);
  }
}