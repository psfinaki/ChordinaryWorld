function makeQuery(artist: string, title: string): string {
    return `artist=${artist}&title=${title}`;
}

function makeUrl(artist: string, title: string): string {
    //const authority = "localhost:48213";
    const authority = "chordinaryworld.azurewebsites.net";
    const query = makeQuery(artist, title);

    return `http://${authority}/api/chords?${query}`;
}