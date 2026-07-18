using System;
using System.Collections.Generic;

namespace DemoMVC.Entidades;

public partial class Song
{
    public int SongId { get; set; }

    public string? Title { get; set; }

    public int ArtistId { get; set; }

    public int AlbumId { get; set; }

    public string? Genre { get; set; }

    public decimal UnitPrice { get; set; }
}
