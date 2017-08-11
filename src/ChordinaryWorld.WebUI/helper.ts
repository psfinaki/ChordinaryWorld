function makeQuery(artist: string, title: string): string {
    return `artist=${artist}&title=${title}`;
}

function makeUrl(artist: string, title: string): string {
    //const authority = "localhost:48213";
    const authority = "chordinaryworld.azurewebsites.net";
    const query = makeQuery(artist, title);

    return `http://${authority}/api/chords?${query}`;
}

function translateResult(result: number): string {
    switch (result) {
        case -1:
            return "Chords to this song cannot be retrieved.";
        case -2:
            return "Empty input is not allowed.";
        case -3:
            return "There is a problem with the chords found. Please write developers about this song."
        default:
            return `Number of harmonies here is ${result}.`;
    }
}