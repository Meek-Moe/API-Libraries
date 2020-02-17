using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Meek.Moe.Enums
{
    public enum Endpoints
    {
        [Description("/diva")]
        ProjectDiva = 0,
        [Description("/rin")]
        KagamineRin = 1,
        [Description("/una")]
        OtomachiUna = 2,
        [Description("/gumi")]
        Gumi = 3,
        [Description("/luka")]
        MegurineLuka = 4,
        [Description("/ia")]
        IA = 5,
        [Description("/fukase")]
        Fukase = 6,
        [Description("/miku")]
        HatsuneMiku = 7,
        [Description("/len")]
        KagamineLen = 8,
        [Description("/kaito")]
        Kaito = 9,
        [Description("/teto")]
        KasaneTeto = 10,
        [Description("/meiko")]
        Meiko = 11,
        [Description("/yukari")]
        YuzukiYukari = 12,
        [Description("/miki")]
        SF2AMiki = 13,
        [Description("/lily")]
        Lily = 14,
        [Description("/mayu")]
        Mayu = 15,
        [Description("/aoki")]
        AokiLapis = 16,
        [Description("/zola")]
        ZOLA = 17
    }
}
