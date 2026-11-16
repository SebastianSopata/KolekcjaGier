using SQLite;
using KolekcjaGier.Models;

namespace KolekcjaGier.Services
{
    public class GryBaza
    {
        private SQLiteAsyncConnection? _db;

        private async Task<SQLiteAsyncConnection> Init()
        {
            if (_db is not null)
                return _db;

            string sciezka = Path.Combine(FileSystem.AppDataDirectory, "gry.db3");
            _db = new SQLiteAsyncConnection(sciezka);
            await _db.CreateTableAsync<Gra>();

            // Wstaw dane startowe tylko wtedy, gdy tabela jest pusta
            if (await _db.Table<Gra>().CountAsync() == 0)
            {
                var startowe = new List<Gra>
                {
                    new Gra { Tytul = "Wiedźmin 3: Dziki Gon", Platforma = "PS4", RokWydania = 2015, WersjaPudelkowa = true, Ocena = 10.0, DataDodania = new DateTime(2021, 5, 10), Zdjecie = "wiedzmin3.jpg" },
                    new Gra { Tytul = "Minecraft", Platforma = "PC", RokWydania = 2011, WersjaPudelkowa = false, Ocena = 9.0, DataDodania = new DateTime(2018, 8, 15), Zdjecie = "minecraft.jpg" },
                    new Gra { Tytul = "Cyberpunk 2077", Platforma = "PS5", RokWydania = 2020, WersjaPudelkowa = true, Ocena = 8.5, DataDodania = new DateTime(2023, 1, 5), Zdjecie = "dotnet_bot.png" },
                    new Gra { Tytul = "Red Dead Redemption 2", Platforma = "Xbox One", RokWydania = 2018, WersjaPudelkowa = true, Ocena = 9.5, DataDodania = new DateTime(2021, 11, 20), Zdjecie = "dotnet_bot.png" },
                    new Gra { Tytul = "Stardew Valley", Platforma = "Switch", RokWydania = 2016, WersjaPudelkowa = false, Ocena = 9.0, DataDodania = new DateTime(2023, 3, 12), Zdjecie = "dotnet_bot.png" }
                };
                await _db.InsertAllAsync(startowe);
            }

            return _db;
        }

        public async Task<List<Gra>> PobierzWszystkieAsync()
        {
            var db = await Init();
            return await db.Table<Gra>().ToListAsync();
        }

        public async Task ZapiszAsync(Gra gra)
        {
            var db = await Init();
            if (gra.Id == 0)
                await db.InsertAsync(gra);
            else
                await db.UpdateAsync(gra);
        }

        public async Task UsunAsync(Gra gra)
        {
            var db = await Init();
            await db.DeleteAsync(gra);
        }
    }
}