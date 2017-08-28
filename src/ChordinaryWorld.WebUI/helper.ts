function makeQuery(artist: string, title: string): string {
    const sanitizedArtist = encodeURIComponent(artist);
    const sanitizedTitle = encodeURIComponent(title);

    return `artist=${sanitizedArtist}&title=${sanitizedTitle}`;
}

function makeUrl(artist: string, title: string): string {
    //const authority = "localhost:48213";
    const authority = "chordinaryworld.azurewebsites.net";
    const query = makeQuery(artist, title);

    return `http://${authority}/api/harmonies?${query}`;
}

function formatSuccess(harmonies: number): string {
    return `Number of harmonies here is ${harmonies}.`;
}

function formatFailure(error: string): string {
    switch (error) {
        case "ChordsNotFound":
            return "Chords to this song cannot be retrieved.";
        case "EmptyInput":
            return "Empty input is not allowed.";
        case "UnknownFlavour":
            return "There is a problem with the chords found. Please write developers about this song."
        default:
            return "There is an internal problem with the service. Please write developers about this song.";
    }
}