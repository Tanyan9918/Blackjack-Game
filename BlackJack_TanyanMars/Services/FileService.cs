using Microsoft.Data.Sqlite;

namespace BlackJack_TanyanMars.Services
{
    /// <summary>
    /// Handles the database file
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// The file path to the database file
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// sets the file path of the database
        /// </summary>
        public FileService()
        {
            var databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "CardImagesURL.db");
            if (!File.Exists(databasePath))
            {
                throw new FileNotFoundException($"Database file not found at {databasePath}");
            }
            _filePath = $"Data Source={databasePath}";
        }

        /// <summary>
        /// Fetches the ImageURL for a card based on its Rank and Suit.
        /// </summary>
        /// <param name="rank">The rank of the card</param>
        /// <param name="suit">The suit of the card</param>
        /// <returns>The ImageURL as a string</returns>
        public async Task<string?> GetCardImageUrlAsync(string rank, string suit)
        {
            try
            {
                using (var connection = new SqliteConnection(_filePath))
                {
                    await connection.OpenAsync();

                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT Image FROM BlackJack WHERE Rank = @Rank AND Suit = @Suit";
                    command.Parameters.AddWithValue("@Rank", rank);
                    command.Parameters.AddWithValue("@Suit", suit);

                    var result = await command.ExecuteScalarAsync();
                    return result?.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching card image URL.", ex);
            }
        }
    }
}


