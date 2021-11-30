using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AoC.Common.Settings;
using Microsoft.Extensions.Configuration;

namespace AoC.Common;

public class PuzzleInputProvider
{
    private readonly IConfiguration _configuration;
    public PuzzleInputProvider()
    {
        _configuration = SettingsProvider.Initialize();
    }

    public async Task<PuzzleInput> GetAsync(int year, int day, params string[] extraParameters)
    {
        var lines = await GetInputFileLines(year, day);
        return new PuzzleInput(lines, extraParameters);
    }

    private async Task<IEnumerable<string>> GetInputFileLines(int year, int day)
    {
        var filePath = GetInputFilePath(year, day);

        if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
        {
            var inputData = await DownloadInputFileData(year, day);
            await File.WriteAllBytesAsync(filePath, inputData);
        }

        return await File.ReadAllLinesAsync(filePath);
    }

    private async Task<byte[]> DownloadInputFileData(int year, int day)
    {
        // requests are so infrequent that we don't have the need to reuse the client
        using var client = GetHttpClient();
        var response = await client.GetAsync(GetInputEndpoint(year, day));
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsByteArrayAsync();
    }

    private string GetInputEndpoint(int year, int day) => $"{year}/day/{day}/input";

    private string GetInputFilePath(int year, int day) => Path.Combine(GetInputFolderPath(year), $"{day}.input");

    private string GetInputFolderPath(int year)
    {
        var inputFolderPath = Path.Combine(Path.GetTempPath(), "AoC", $"{year}");

        if (!Directory.Exists(inputFolderPath))
        {
            Directory.CreateDirectory(inputFolderPath);
        }

        return inputFolderPath;
    }

    private HttpClient GetHttpClient()
    {
        var baseUri = new Uri("https://adventofcode.com");
        return new HttpClient(GetHandler(baseUri)) { BaseAddress = baseUri };
    }

    private HttpClientHandler GetHandler(Uri baseUri)
    {
        var container = new CookieContainer();
        container.Add(baseUri, CreateSessionCookie());
        
        return new HttpClientHandler
        {
            CookieContainer = container,
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };
    }


    private Cookie CreateSessionCookie()
    {
        var value = _configuration["Session"];
        var expiration = DateTime.Parse(_configuration["Expiration"]);

        return new Cookie()
        {
            Name = "session",
            Domain = ".adventofcode.com",
            Path = "/",
            Expires = expiration,
            Value = value,
            HttpOnly = true
        };
    }
}
