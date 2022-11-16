public class Bmi
{
  public static (double,double) ParseMetric(string line)
  {
    // <###.###>kg<white-space><###.###><cm|m>
    var height = Foot2meter(6.0+1.0/12.0);
    var weight = Pounds2kg(214.0);
    if (!string.IsNullOrEmpty(line))
    {
      var temp = 0.0;
      var parts = line.Split(" ");
      if ((parts.Count() > 0) 
        && (double.TryParse(new String(
          parts[0].Where(c => { return char.IsDigit(c) || c=='.'; }).ToArray()), out temp)))
      {
        weight = temp;
      }
      if ((parts.Count() > 1) 
        && (double.TryParse(new String(
          parts[1].Where(c => { return char.IsDigit(c) || c=='.'; }).ToArray()), out temp)))
      {
        height = temp;
      }
    }
    return (height, weight);
  }
  public static (double,double) ParseImperial(string line)
  {
    // <###.###>pounds[<white-space><###.###><ft>[<white><###.##><in>]]
    var height = Foot2meter(6.0+1.0/12.0);
    var weight = Pounds2kg(214.0);
    if (!string.IsNullOrEmpty(line))
    {
      var temp = 0.0;
      var parts = line.Split(" ");
      if ((parts.Count() > 0) 
        && (double.TryParse(new String(
          parts[0].Where(c => { return char.IsDigit(c) || c=='.'; }).ToArray()), out temp)))
      {
        weight = Pounds2kg(temp);
      }
      if ((parts.Count() > 1) 
        && (double.TryParse(new String(
          parts[1].Where(c => { return char.IsDigit(c) || c=='.'; }).ToArray()), out temp)))
      {
        height = Foot2meter(temp);
        if ((parts.Count() > 2) 
          && (double.TryParse(
            new String(parts[2].Where(Char.IsDigit).ToArray()), out temp)))
        {
          height += Inch2meter(temp);
        }
      }
    }
    return (height, weight);
  }
  public static string GetLineFromConsole(string prompt)
  {
    var line = string.Empty;
    do {
      Console.WriteLine(prompt);
      line = Console.ReadLine();
    } while (string.IsNullOrEmpty(line));
    return line;
  }
  public static (double, double) GetInputs(string[] argv, Func<string,string> getter, string prompt)
  {
    var line = (argv.Count() < 1)
      ? getter(prompt)
      : string.Join(" ",argv);

    return (line.Contains("kg")) 
      ? ParseMetric(line) 
      : ParseImperial(line);
  }
  public static double Pounds2kg(double lbs) { return lbs/2.204623; }
  public static double Foot2meter(double foot) { return foot/3.28084; }
  public static double Inch2meter(double inch) { return inch/39.37008; }
  public static double Squared (double x) { return x * x; }
  public static double BmiCalc((double,double) t) { return BmiCalc(t.Item1,t.Item2); }
  public static double BmiCalc(double height, double weight) { return weight / Squared(height); }
  static void Main(string[] argv)
  {
    var inputs = GetInputs(argv, GetLineFromConsole, "Enter your weight [and height]: ");
    var bmi_value = BmiCalc(inputs);
    Console.WriteLine($"Height: {inputs.Item1} Weight: {inputs.Item2} BMI: {bmi_value};");
  }
}