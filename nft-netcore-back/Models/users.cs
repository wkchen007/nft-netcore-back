using System;
using System.Collections.Generic;

namespace nft_netcore_back.Models;

public partial class users
{
    public int id { get; set; }

    public string first_name { get; set; } = null!;

    public string last_name { get; set; } = null!;

    public string email { get; set; } = null!;

    public string password { get; set; } = null!;

    public string wallet_address { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }
}
