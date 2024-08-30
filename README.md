# PokemonAPI
 Software Engineering Challenge for TrueLayer

To test the endpoints:
1. clone the repo
2. if needed, install docker
3. launch the following command in the main folder of the project: "docker build -t image-name ."
4. launch the following command: "docker run -d -p 8080:8080 image-name"

After that, you can test the following endpoints:
- http://localhost:8080/pokemon/{pokemon-name}
- http://localhost:8080/pokemon/translated/{pokemon-name}

Since it was not specified by requirements, the API will actually return a pokemon even if using a id number corresponding to a PokeAPI existing ID.

Possible improvements for prod:
- test integrations
- using HttpClientFactory for client instantiating (for better scaling)
- swagger docs
