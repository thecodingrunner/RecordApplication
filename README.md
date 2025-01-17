





Method Name | Method Endpoint | HTTP Method | Example Input
--- | --- | --- | ---
GetAlbums() | "api/album" | Get | -
GetAlbumById() | "api/album/{id}" | Get | Param: "api/album/3"
PostAlbum() | "api/album" | Post | Post body: { "albumName": "Cheat Codes", "artistName": "Danger Mouse", "releaseYear": 2022, "units": 6, "genre": "HipHop", "description": "Collaboration album with Black thought" }
PutAlbum() | "api/album/{id}" | Put | Post body: { "albumName": "Cheat Codes", "artistName": "Danger Mouse", "releaseYear": 2022, "units": 6, "genre": "HipHop", "description": "Collaboration album with Black thought" } /n Param: "api/album/1"
