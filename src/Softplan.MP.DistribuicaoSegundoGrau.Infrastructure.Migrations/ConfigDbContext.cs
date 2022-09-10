namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations
{
    public class ConfigDbContext
    {
        public const string LOCAL_SAJ_CONNECTION_STRING_POSTGRES = "Host=localhost;Database=postgres;Username=user;Password=pass";
        public const string LOCAL_DSG_CONNECTION_STRING_POSTGRES = "Host=172.21.9.195;Port=5432;Database=postgres;Username=SAJDSG;Password=agesune1";

        public const string LOCAL_DSG_CONNECTION_STRING_ORACLE = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=172.21.9.197)(PORT=1521))(CONNECT_DATA=(SID=UNJ01TIN)));User Id=SAJDSG;Password=agesune1";
        public const string LOCAL_SAJ_CONNECTION_STRING_ORACLE = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=172.21.9.197)(PORT=1521))(CONNECT_DATA=(SID=SIGTINT)));User Id=SAJ;Password=agesune1";
        
        public const string DEVART_ORACLE_LICENSE = "NdV9nur7ypG+rgqM8gwcHgqer2k1CSiaHdlGO4dlI6VwaBOF2DyzkLqs37/2VqfUIVEBEqLb8Tk94pEWm3g5/TarbXqZiYFH7J7WcFfnr1hODQAZsce9pUWDLUcXUCf1FF2/nQGdo2AujlyUdQtmNDZgSngV5ZPJfEeAYNPAm3ptD1a22ztRjQDzG68uBAquBNHeSeFIJt1e2eITY+10RuVV4DYV04558tHVSFapJUq2zGip6obgSSIrNrUTh21V8Zo0rOZATeWsoeRES4TUJWSwOo7vIavxasHn8FJW1LtG/oAj2iFZbBFakoXN5yqRYXsS9+jquTF6e+hHX6IOuQHzBkb3p1zKSOeK8E+2AVhwhEjVdTDlFxRb+GBbnDD/";
    }
}