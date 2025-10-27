using System;
using System.Collections.Generic;

namespace nft_netcore_back.Models;

public partial class nft
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string description { get; set; } = null!;

    public string meta { get; set; } = null!;

    public string image { get; set; } = null!;

    public int demo { get; set; }

    public int? userId { get; set; }
}
