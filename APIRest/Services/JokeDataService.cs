using APIRest.Interfaces;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace APIRest.Services
{
    public class JokeDataService : BaseDataService, IJokeDataService
    {
        public async Task<string> InsertJoke(string chisteText)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {

                        try
                        {
                            await con.OpenAsync();

                            cmd.CommandText = @"INSERT INTO Joke(Body) VALUES(@JokeId, @Body)";

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@JokeId", 13);
                            cmd.Parameters.AddWithValue("@Body", chisteText);

                            await cmd.ExecuteNonQueryAsync();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return chisteText;
        }

        public async Task<bool> UpdateJoke(int jokeId, string jokeBody)
        {
            bool updated = false;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {

                        try
                        {
                            await con.OpenAsync();

                            cmd.CommandText = @"UPDATE [dbo].[Joke] 
                                                SET [Body] = @Body
                                                WHERE JokeId = @JokeId";

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@JokeId", jokeId);
                            cmd.Parameters.AddWithValue("@Body", jokeBody);

                            updated = await cmd.ExecuteNonQueryAsync() > 0;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return updated;
        }

        public async Task<bool> DeleteJoke(int jokeId)
        {
            bool deleted = false;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {

                        try
                        {
                            await con.OpenAsync();

                            cmd.CommandText = @"DELETE FROM [dbo].[Joke]
                                                WHERE JokeId = @JokeId";

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@JokeId", jokeId);

                            deleted = await cmd.ExecuteNonQueryAsync() > 0;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return deleted;
        }
    }
}