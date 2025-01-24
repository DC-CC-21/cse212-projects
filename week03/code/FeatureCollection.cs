public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public string type { get; set; }
    public Metadata metadata { get; set; }
    public Features[] features { get; set; }
    public double[] bbox { get; set; }
}

public class Metadata
{
    public double generated { get; set; }
    public string url { get; set; }
    public string title { get; set; }
    public double status { get; set; }
    public string api { get; set; }
    public double count { get; set; }
}

public class Features
{
    public string type { get; set; }
    public Properties properties { get; set; }
    public Geometry geometry { get; set; }
    public string id { get; set; }
}
public class Properties
{
    public double? mag { get; set; }
    public string place { get; set; }
    public double time { get; set; }
    public double updated { get; set; }
    public string url { get; set; }
    public string detail { get; set; }
    public string status { get; set; }
    public double tsunami { get; set; }
    public double sig { get; set; }
    public string net { get; set; }
    public string code { get; set; }
    public string ids { get; set; }
    public string sources { get; set; }
    public string types { get; set; }
    public double? nst { get; set; }
    public double? dmin { get; set; }
    public double rms { get; set; }
    public double? gap { get; set; }
    public string magType { get; set; }
    public string type { get; set; }
    public string title { get; set; }
};

public class Geometry
{
    public string type { get; set; }
    public double[] coordinates { get; set; }
}