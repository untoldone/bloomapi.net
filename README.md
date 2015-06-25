BloomAPI.net
============

A .net client to [BloomAPI](http://www.bloomapi.com).

Currently a work in progress ... stay tuned.

# Setup

BloomAPI.net is available on NuGet via

    PS> Install-Package BloomApi.net

To Build it yourself, open BloomApi.sln and build.

# Examples

**Create a new client**

	// Basic
	BloomService service = new BloomService("<api key here>");

	// If using an API Key
    BloomService service = new BloomService("<api key here>");

    // If using your own server (with or without your own API keys)
    BloomService service = new BloomService("<api key here or null>", "http://www.bloomapi.com/api");

**Query available datasources**

    BloomApiSourcesResponse response = service.Sources();

    foreach (BloomApiSource sourceMeta in response.Result)
    {
        Console.WriteLine(sourceMeta.Source);
    }

**Search the National Provider Identifier (NPI) without parameters**

    BloomApiSearchResponse response = service.Search("usgov.hhs.npi");

    foreach (var npi in response.Result)
    {
        Console.WriteLine(npi["first_name"]);
    }

**Search HCPCS Procedure Codes for the code 'C9289'**

    BloomApiSearchResponse response = service.Search("usgov.hhs.hcpcs", new BloomApiSearchOptions
    {
        Terms = new List<BloomApiSearchTerm>
        {
            new BloomApiSearchTerm{
                Key = "code",
                Operation = BloomApiSearchOperation.Equals,
                Value = "C9289"
            }
        }
    });

    Console.WriteLine(response.Result[0]["long_description"]);

**Page through search results**

	BloomApiSearchResponse response;
    bool more = true;
    uint offset = 0;
    List<JObject> npis = new List<JObject>();

    while (more)
    {
        response = service.Search("usgov.hhs.hcpcs", new BloomApiSearchOptions
        {
            Offset = offset,
            Terms = new List<BloomApiSearchTerm>
            {
                new BloomApiSearchTerm{
                    Key = "last_name",
                    Operation = BloomApiSearchOperation.Equals,
                    Value = "murillo"
                }
            }
        });

        npis.AddRange(response.Result);

        if (response.Meta.RowCount - offset <= 100) more = false;
    }

    foreach (var npi in npis)
    {
        Console.WriteLine(npi["npi"]);
    }


**Search HCPCS Procedure Codes for any code with word that starts with 'ambula' in the description'**
This also specifies an offset and limit using the options parameter.

    BloomApiSearchResponse response = service.Search("usgov.hhs.hcpcs", new BloomApiSearchOptions
    {
        Terms = new List<BloomApiSearchTerm>
        {
            new BloomApiSearchTerm{
                Key = "long_description",
                Operation = BloomApiSearchOperation.Prefix,
                Value = "ambula"
            }
        }
    });

    Console.WriteLine(response.Result[0]["long_description"]);

**Search HCPCS for both code 'L8410' and 'C9289' (Logical OR)**

    BloomApiSearchResponse response = service.Search("usgov.hhs.hcpcs", new BloomApiSearchOptions
    {
        Terms = new List<BloomApiSearchTerm>
        {
            new BloomApiSearchTerm{
                Key = "code",
                Operation = BloomApiSearchOperation.Equals,
                Values = new List<string>
                {
                    "L8410",
                    "C9289"
                }
            }
        }
    });

**Find a National Provider Identifier its NPI**

	BloomApiFindResponse response = service.Find("usgov.hhs.npi", "1770707127");

    Console.WriteLine(response.Result["first_name"]);